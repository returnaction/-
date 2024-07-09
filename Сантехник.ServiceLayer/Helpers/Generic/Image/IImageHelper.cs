using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Сантехник.CoreLayer.Enumerators;
using Сантехник.CoreLayer.Models;

namespace Сантехник.ServiceLayer.Helpers.Generic.Image
{
    public interface IImageHelper
    {
        Task<ImageUploadModel> ImageUpload(IFormFile imageFile, ImageType imageType, string? folderName);
        string DeleteImage(string imageName);
    }
}
