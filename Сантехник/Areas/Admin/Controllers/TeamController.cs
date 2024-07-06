using Microsoft.AspNetCore.Mvc;
using Сантехник.EntityLayer.WebApplication.ViewModels.TeamVM;
using Сантехник.ServiceLayer.Services.Abstract;

namespace Сантехник.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TeamController : Controller
    {
        private readonly ITeamService _teamService;

        public TeamController(ITeamService teamService)
        {
            _teamService = teamService;
        }

        
        public async Task<IActionResult> GetTeamList()
        {
            var teamList = await _teamService.GetAllListAsync();
            return View(teamList);
        }

        public IActionResult AddTeam()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddTeam(TeamAddVM request)
        {
            await _teamService.AddTeamService(request);
            return RedirectToAction("GetTeamList", "Team", new { Area = ("Admin") });
        }

        public async Task<IActionResult> UpdateTeam(int id)
        {
            var team = await _teamService.GetTeamById(id);
            return View(team);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateTeam(TeamUpdateVM request)
        {
            await _teamService.UpdateTeamAsync(request);
            return RedirectToAction("GetTeamList", "Team", new { Area = ("Admin") });
        }

        public async Task<IActionResult> DeleteTeam(int id)
        {
            await _teamService.DeleteTeamAsync(id);
            return RedirectToAction("GetTeamList", "Team", new { Area = ("Admin") });
        }
    }
}
