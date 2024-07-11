using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Сантехник.EntityLayer.WebApplication.ViewModels.TeamVM;

namespace Сантехник.ServiceLayer.Services.WebApplication.Abstract
{
    public interface ITeamService
    {
        Task AddTeamService(TeamAddVM request);
        Task DeleteTeamAsync(int id);
        Task<List<TeamListVM>> GetAllListAsync();
        Task<TeamUpdateVM> GetTeamById(int id);
        Task UpdateTeamAsync(TeamUpdateVM request);

        Task<List<TeamListForUI>> GetAllListForUIAsync();
    }
}
