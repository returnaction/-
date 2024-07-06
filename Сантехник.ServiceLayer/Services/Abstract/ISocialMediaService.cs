using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Сантехник.EntityLayer.WebApplication.ViewModels.SocialMediaVM;

namespace Сантехник.ServiceLayer.Services.Abstract
{
    public interface ISocialMediaService
    {
        Task AddSocialMediaService(SocialMediaAddVM request);
        Task DeleteSocialMediaAsync(int id);
        Task<List<SocialMediaListVM>> GetAllListAsync();
        Task<SocialMediaUpdateVM> GetSocialMediaById(int id);
        Task UpdateSocialMediaAsync(SocialMediaUpdateVM request);
    }
}
