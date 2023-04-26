using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.FileProviders;
using System.Reflection;

namespace TestTask.DataAccess
{
    public static class WebApplicationExtensions
    {
        public static void UseCustomStaticImagesFolder(this WebApplication app, string? imagesDirectory = null)
        {
            if (imagesDirectory == null)
            {
                string directory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)!;
                imagesDirectory = Path.Combine(directory, "Images");
            }

            if (!Directory.Exists(imagesDirectory))
            {
                Directory.CreateDirectory(imagesDirectory);
            }

            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(imagesDirectory),
                RequestPath = "/Images"
            });
        }
    }
}
