namespace CarRentalSystem.Services.Data.Interfaces
{
	using Web.ViewModels.Images;


	public interface IImageService
	{
		Task Process(IEnumerable<ImageInputModel> images);

		Task<Stream> GetThumbnail(string id);
		Task<Stream> GetFullscreen(string id);

		Task<List<string>> GetAllImages();
	}
}
