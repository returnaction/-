using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Сантехник.EntityLayer.WebApplication.Entities;
using Сантехник.EntityLayer.WebApplication.ViewModels.AboutVM;

namespace Сантехник.ServiceLayer.Automapper.WebApplication
{
    public class AboutMapper : Profile
    {
        public AboutMapper()
        {
            CreateMap<About, AboutAddVM>().ReverseMap();
            CreateMap<About, AboutListVM>().ReverseMap();
            CreateMap<About, AboutUpdateVM>().ReverseMap();
        }
    }
}
