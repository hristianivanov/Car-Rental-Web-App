using Microsoft.AspNetCore.Identity;

namespace CarRentalSystem.Web
{
	using Microsoft.EntityFrameworkCore;

	using Data;
	using Data.Models;

	using Services.Data.Interfaces;
	using Infrastructure.ModelBinders;
	using Infrastructure.Extensions;
	using Microsoft.AspNetCore.Mvc;

	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			var connectionString =
				builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

			builder.Services.AddDbContext<CarRentingDbContext>(options =>
				options.UseSqlServer(connectionString));

			builder.Services.AddDefaultIdentity<User>(options =>
				{
					options.SignIn.RequireConfirmedAccount =
						builder.Configuration.GetValue<bool>("Identity:SignIn:RequireConfirmedAccount");
					options.Password.RequireLowercase =
						builder.Configuration.GetValue<bool>("Identity:Password:RequireLowercase");
					options.Password.RequireUppercase =
						builder.Configuration.GetValue<bool>("Identity:Password:RequireUppercase"); ;
					options.Password.RequireNonAlphanumeric =
						builder.Configuration.GetValue<bool>("Identity:Password:RequireNonAlphanumeric"); ;
					options.Password.RequiredLength =
						builder.Configuration.GetValue<int>("Identity:Password:RequiredLength"); ;
				})
				.AddRoles<IdentityRole<Guid>>()
				.AddEntityFrameworkStores<CarRentingDbContext>();

			builder.Services.AddApplicationServices(typeof(ICarService));

			builder.Services.AddMemoryCache();

			builder.Services.ConfigureApplicationCookie(cfg =>
			{
				cfg.LoginPath = "/User/Login";
				cfg.AccessDeniedPath = "/Home/Error/401";
			});

			builder.Services
				.AddControllersWithViews()
				.AddMvcOptions(options =>
				{
					options.ModelBinderProviders.Insert(0, new DecimalModelBinderProvider());
					options.Filters.Add<AutoValidateAntiforgeryTokenAttribute>();
				});
			//builder.Services.AddRazorPages();

			var app = builder.Build();

			if (app.Environment.IsDevelopment())
			{
				app.UseMigrationsEndPoint();
				app.UseDeveloperExceptionPage();
			}
			else
			{
				app.UseExceptionHandler("/Home/Error/500");
				app.UseStatusCodePagesWithRedirects("/Home/Error?statusCode={0}");

				app.UseHsts();
			}

			app.UseHttpsRedirection();
			app.UseStaticFiles();

			app.UseRouting();

			app.UseAuthentication();
			app.UseAuthorization();

			app.EnableOnlineUsersCheck();

			if (app.Environment.IsDevelopment())
			{
				//app.SeedAdministrator(DevelopmentAdminEmail);
			}

			//if you had custom routing
			app.UseEndpoints(config =>
			{
				config.MapControllerRoute(
					name: "areas",
					pattern: "/{area:exists}/{controller=Home}/{action=Index}/{id?}"
				);

				//protectingUrl here

				config.MapDefaultControllerRoute();

				config.MapRazorPages();
			});

			app.MapRazorPages();

			app.Run();
		}
	}
}