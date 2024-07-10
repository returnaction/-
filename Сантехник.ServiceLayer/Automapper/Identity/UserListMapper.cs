using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Сантехник.EntityLayer.Identity.Entities;
using Сантехник.EntityLayer.Identity.ViewModels;

namespace Сантехник.ServiceLayer.Automapper.Identity
{
    public class UserListMapper : Profile
    {
        public UserListMapper()
        {
            CreateMap<AppUser, UserVM>().ReverseMap();
        }
    }
}
