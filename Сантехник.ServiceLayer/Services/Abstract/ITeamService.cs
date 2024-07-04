using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Сантехник.EntityLayer.WebApplication.ViewModels.TeamVM;

namespace Сантехник.ServiceLayer.Services.Abstract
{
    public interface ITeamService
    {
        Task AddCategoryService(TeamAddVM request);
        Task DeleteCategoryAsync(int id);
        Task<List<TeamListVM>> GetAllListAsync();
        Task<TeamUpdateVM> GetCategoryById(int id);
        Task UpdateCategoryAsync(TeamUpdateVM request);
    }
}
