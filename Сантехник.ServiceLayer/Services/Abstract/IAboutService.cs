using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Сантехник.EntityLayer.WebApplication.ViewModels.AboutVM;

namespace Сантехник.ServiceLayer.Services.Abstract
{
    public interface IAboutService
    {
        Task AddAboutAsync(AboutAddVM request);
        Task DeleteAboutAsync(int id);
        Task<AboutUpdateVM> GetAboutBYId(int id);
        Task<List<AboutListVM>> GetAllListAsync();
        Task UpdateAboutAsync(AboutUpdateVM request);
    }
}
