using Сантехник.EntityLayer.WebApplication.ViewModels.SocialMediaVM;

namespace Сантехник.ServiceLayer.Services.Concrete
{
    public interface ISocialMediaService
    {
        Task AddCategoryService(SocialMediaAddVM request);
        Task DeleteCategoryAsync(int id);
        Task<List<SocialMediaListVM>> GetAllListAsync();
        Task<SocialMediaUpdateVM> GetCategoryById(int id);
        Task UpdateCategoryAsync(SocialMediaUpdateVM request);
    }
}