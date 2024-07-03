using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Сантехник.EntityLayer.WebApplication.Entities;
using Сантехник.EntityLayer.WebApplication.ViewModels.TeamVM;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Сантехник.ServiceLayer.Automapper
{
    public class TeamMapper : Profile
    {
        public TeamMapper()
        {
            CreateMap<Team, TeamAddVM>().ReverseMap();
            CreateMap<Team, TeamListVM>().ReverseMap();
            CreateMap<Team, TeamUpdateVM>().ReverseMap();
        }
    }
}
