using CarRentalSystem.Data;
using Microsoft.EntityFrameworkCore;

namespace CarRentalSystem.Services.Data
{
	using SixLabors.ImageSharp;
	using SixLabors.ImageSharp.Formats.Jpeg;

	using Interfaces;
	using Web.ViewModels.Images;
	using Image = SixLabors.ImageSharp.Image;
	using Microsoft.Extensions.DependencyInjection;
	using System.Net;
	using Microsoft.Data.SqlClient;

	public class ImageService : IImageService
	{
		//image storage service , image processor service
		private const int ThumbnailWidth = 300;
		private const int FullscreenWidth = 1000;

		private readonly IServiceScopeFactory serviceScopeFactory;
		private readonly CarRentingDbContext data;
		public ImageService(IServiceScopeFactory serviceScopeFactory, CarRentingDbContext data)
		{
			this.serviceScopeFactory = serviceScopeFactory;
			this.data = data;
		}

		public async Task Process(IEnumerable<ImageInputModel> images)
		{
			var tasks = images
				.Select(image => Task.Run(async () =>
				{
					try
					{
						using var imageResult = await Image.LoadAsync(image.Content);

						//await this.SaveImage(imageResult, $"Original_{image.Name}", imageResult.Width);
						var original= await this.SaveImage(imageResult, imageResult.Width);
						var fullscreen = await this.SaveImage(imageResult, FullscreenWidth);
						var thumbnail = await this.SaveImage(imageResult, ThumbnailWidth);

						var database = this.serviceScopeFactory
							.CreateScope()
							.ServiceProvider
							.GetRequiredService<CarRentingDbContext>();

						database.ImageData.Add(new CarRentalSystem.Data.Models.ImageData
						{
							OriginalFileName = image.Name,
							OriginalType = image.Type,
							OriginalContent = original,
							ThumbnailContent = thumbnail,
							FullscreenContent = fullscreen,
						});

						await database.SaveChangesAsync();
					}
					catch
					{
						// Log information
					}
					
				})).ToList();

			await Task.WhenAll(tasks);
		}

		public Task<Stream> GetThumbnail(string id)
			=> this.GetImageData(id, "Thumbnail");

		public Task<Stream> GetFullscreen(string id)
			=> this.GetImageData(id, "Fullscreen");

		private async Task<Stream> GetImageData(string id,string size)
		{
			var database = this.data.Database;

			var dbConnection = (SqlConnection)database.GetDbConnection();

			var command = new SqlCommand(
				$"SELECT {size}Content FROM ImageData WHERE Id = @id;",
				dbConnection);

			command.Parameters.Add(new SqlParameter("@id", id));

			dbConnection.Open();

			var reader = await command.ExecuteReaderAsync();

			Stream result = null;

			if (reader.HasRows)
			{
				while (reader.Read()) result = reader.GetStream(0);
			}

			reader.Close();

			return result;
		}

		public Task<List<string>> GetAllImages()
		=> this.data
			.ImageData
			.Select(i => i.Id.ToString())
			.ToListAsync();

		private async Task<byte[]> SaveImage(Image image, int resizedWidth)
		{
			var width = image.Width;
			var height = image.Height;

			if (width > resizedWidth)
			{
				height = (int)((double)resizedWidth / width * height);
				width = resizedWidth;
			}

			image.Mutate(i => i
				.Resize(new Size(width, height)));
			image.Metadata.ExifProfile = null;

			var memoryStream = new MemoryStream();



			await image.SaveAsJpegAsync(memoryStream, new JpegEncoder()
			{
				Quality = 75
			});

			return memoryStream.ToArray();
		}
	}
}
