using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Сантехник.EntityLayer.WebApplication.Entities;
using Сантехник.EntityLayer.WebApplication.ViewModels.AboutVM;
using Сантехник.EntityLayer.WebApplication.ViewModels.ServiceVM;

namespace Сантехник.ServiceLayer.Automapper.WebApplication
{
    public class ServiceMapper : Profile
    {
        public ServiceMapper()
        {
            CreateMap<Service, ServiceAddVM>().ReverseMap();
            CreateMap<Service, ServiceListVM>().ReverseMap();
            CreateMap<Service, ServiceUpdateVM>().ReverseMap();

            CreateMap<Service, ServiceListForUI>().ReverseMap();
        }
    }
}
