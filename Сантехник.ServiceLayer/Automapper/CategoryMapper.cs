using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Сантехник.EntityLayer.WebApplication.Entities;
using Сантехник.EntityLayer.WebApplication.ViewModels.AboutVM;
using Сантехник.EntityLayer.WebApplication.ViewModels.CategoryVM;

namespace Сантехник.ServiceLayer.Automapper
{
    public class CategoryMapper : Profile
    {
        public CategoryMapper()
        {
            CreateMap<Category,CategoryAddVM>().ReverseMap();
            CreateMap<Category,CategoryListVM>().ReverseMap();
            CreateMap<Category,CategoryUpdateVM>().ReverseMap();
        }
    }
}
