using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Сантехник.EntityLayer.WebApplication.ViewModels.PortfolioVM;

namespace Сантехник.ServiceLayer.Services.Abstract
{
    public interface IPortfolioService
    {
        Task AddPortfolioService(PortfolioAddVM request);
        Task DeletePortfolioAsync(int id);
        Task<List<PortfolioListVM>> GetAllListAsync();
        Task<PortfolioUpdateVM> GetPortfolioById(int id);
        Task UpdatePortfolioAsync(PortfolioUpdateVM request);
    }
}
