using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Сантехник.EntityLayer.WebApplication.Entities;
using Сантехник.EntityLayer.WebApplication.ViewModels.AboutVM;
using Сантехник.EntityLayer.WebApplication.ViewModels.PortfolioVM;

namespace Сантехник.ServiceLayer.Automapper.WebApplication
{
    public class PortfolioMapper : Profile
    {
        public PortfolioMapper()
        {
            CreateMap<Portfolio, PortfolioAddVM>().ReverseMap();
            CreateMap<Portfolio, PortfolioListVM>().ReverseMap();
            CreateMap<Portfolio, PortfolioUpdateVM>().ReverseMap();


            CreateMap<Portfolio, PortfolioListForUI>().ReverseMap();
        }
    }
}
