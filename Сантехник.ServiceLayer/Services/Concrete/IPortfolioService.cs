using Сантехник.EntityLayer.WebApplication.ViewModels.PortfolioVM;

namespace Сантехник.ServiceLayer.Services.Concrete
{
    public interface IPortfolioService
    {
        Task AddCategoryService(PortfolioAddVM request);
        Task DeleteCategoryAsync(int id);
        Task<List<PortfolioListVM>> GetAllListAsync();
        Task<PortfolioUpdateVM> GetCategoryById(int id);
        Task UpdateCategoryAsync(PortfolioUpdateVM request);
    }
}