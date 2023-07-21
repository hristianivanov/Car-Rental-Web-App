namespace CarRentalSystem.Web
{
    using Microsoft.EntityFrameworkCore;

    using Data;
    using Data.Models;
    using Infrastructure.Extensions;
    using CarRentalSystem.Services.Data.Interfaces;
	using CarRentalSystem.Services.Data;

	public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var connectionString =
                builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

            builder.Services.AddDbContext<CarRentingDbContext>(options =>
                options.UseSqlServer(connectionString));

            builder.Services.AddDefaultIdentity<ApplicationUser>(options =>
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
                .AddEntityFrameworkStores<CarRentingDbContext>();

            //builder.Services.AddApplicationServices(typeof(ICarService));
            builder.Services.AddTransient<IImageService, ImageService>();

            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseMigrationsEndPoint();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            //if you had custom routing
            //app.MapControllerRoute(
            //	name: "default",
            //	pattern: "{controller=Home}/{action=Index}/{id?}");
            app.MapDefaultControllerRoute();

            app.MapRazorPages();

            app.Run();
        }
    }
}