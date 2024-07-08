using Сантехник.RepositoryLayer.Extensions;
using Сантехник.ServiceLayer.Extensions;

namespace Сантехник
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.LoadRepositoryLayerExtensions(builder.Configuration);
            builder.Services.LoadServiceLayerExtensions();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoint =>
            {
                endpoint.MapAreaControllerRoute(
                    name: "Admin",
                    areaName: "Admin",
                    pattern: "Admin/{controller=Dashboard}/{action=Index}/{id?}");

                endpoint.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
            });
           

            app.Run();
        }
    }
}

// bootstrapmade.com layouts


// IQueriable
// AsNoTracking()

//TODO Update doesn't record the type of being updated. Add later


// Dont delete this link some how I managed to find that link to create an app password
// https://myaccount.google.com/apppasswords?pli=1&rapt=AEjHL4Ndf5cYqsqcBR3csOq2B-Zux7WCb_poDjlzDq_mK5a2H3pY7ihd61k5DXUpx8GcZgYE-e2HXHReTr2DBdy89Kw3zuMKxh4ZuArBV0J2HFLEczv3gYk

// YouTubeHelper
// flca lhbd qdsk wamh



