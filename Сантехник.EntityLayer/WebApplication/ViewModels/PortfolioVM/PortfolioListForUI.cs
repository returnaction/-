using Сантехник.EntityLayer.WebApplication.ViewModels.CategoryVM;

namespace Сантехник.EntityLayer.WebApplication.ViewModels.PortfolioVM
{
    public class PortfolioListForUI
    {
        public string Title { get; set; } = null!;

        public string FileName { get; set; } = null!;

        public CategoryListVM Category { get; set; } = null!;
    }
}
