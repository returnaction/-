using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Сантехник.CoreLayer.Enumerators;
using Сантехник.CoreLayer.Models;

namespace Сантехник.ServiceLayer.Helpers.Generic.Image
{
    public class ImageHelper : IImageHelper
    {
        private readonly IHostEnvironment _hostEnvironment;
        private readonly string wwwRoot;
        private const string imageFolder = "images";
        private const string idenityFolder = "user";
        private const string aboutFolder = "aboutUs";
        private const string portfolioFolder = "portfolio";
        private const string teamFolder = "teams";
        private const string testimonialFolder = "testimonials";

        public ImageHelper(IHostEnvironment hostEnvironment)
        {
            _hostEnvironment = hostEnvironment;
            wwwRoot = _hostEnvironment.ContentRootPath + "/wwwroot/";
        }

        public async Task<ImageUploadModel> ImageUpload(IFormFile imageFile, ImageType imageType, string? folderName)
        {
            if (folderName == null)
            {
                switch (imageType)
                {
                    case ImageType.about:
                        folderName = aboutFolder;
                        break;
                    case ImageType.identity:
                        folderName = idenityFolder;
                        break;
                    case ImageType.team:
                        folderName = teamFolder;
                        break;
                    case ImageType.testimonial:
                        folderName = testimonialFolder;
                        break;
                    case ImageType.portfolio:
                        folderName = portfolioFolder;
                        break;
                }
            }

            if (!Directory.Exists($"{wwwRoot}/{imageFolder}/{folderName}"))
            {
                Directory.CreateDirectory($"{wwwRoot}/{imageFolder}/{folderName}");
            }

            string fileExtenstion = Path.GetExtension(imageFile.FileName).ToLower();

            if (fileExtenstion != ".jpg" && fileExtenstion != ".jpeg")
            {
                return new ImageUploadModel
                {
                    Error = "Please only upload JPG or JPEG files"
                };
            }

            DateTime dateTime = DateTime.Now;
            var newfileName = folderName + "_" + dateTime.Microsecond.ToString() + fileExtenstion;

            string path = Path.Combine($"{wwwRoot}/{imageFolder}/{folderName}", newfileName);

            await using var stream = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.None, 1024 * 1024, useAsync: false);
            await imageFile.CopyToAsync(stream);
            await stream.FlushAsync();

            return new ImageUploadModel { Filename = $"{folderName}/{newfileName}", FileType = imageFile.ContentType };

        }

        public string DeleteImage(string imageName)
        {
            var fileToDelete = Path.Combine($"{wwwRoot}/{imageFolder}/{imageName}");
            if (File.Exists(fileToDelete))
            {
                File.Delete(fileToDelete);
            }

            return "Image is Deleted";
        }
    }
}
