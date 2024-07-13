namespace Сантехник.ServiceLayer.Services.WebApplication.Abstract
{
    public interface IDashBoardService
    {
        Task<int> GetAllServicesCountAsync();
        Task<int> GetAllTeamsCountAsync();
        Task<int> GetAllTestimonalsCountAsync();
        Task<int> GetAllCategoriesCountAsync();
        Task<int> GetAllPortfoliosCountAsync();
        int GetAllUsersCountAsync();
    }
}
