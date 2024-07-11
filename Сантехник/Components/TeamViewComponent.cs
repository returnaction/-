using Microsoft.AspNetCore.Mvc;
using Сантехник.ServiceLayer.Services.WebApplication.Abstract;

namespace Сантехник.Components
{
    public class TeamViewComponent : ViewComponent
    {
        private readonly ITeamService _teamService;

        public TeamViewComponent(ITeamService teamService)
        {
            _teamService = teamService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var teamListForUI = await _teamService.GetAllListForUIAsync();

            return View(teamListForUI);
        }
    }
}
