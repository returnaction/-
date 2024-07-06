using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Сантехник.EntityLayer.WebApplication.Entities;
using Сантехник.EntityLayer.WebApplication.ViewModels.AboutVM;
using Сантехник.EntityLayer.WebApplication.ViewModels.ContactVM;

namespace Сантехник.ServiceLayer.Automapper.WebApplication
{
    public class ContactMapper : Profile
    {
        public ContactMapper()
        {
            CreateMap<Contact, ContactAddVM>().ReverseMap();
            CreateMap<Contact, ContactListVM>().ReverseMap();
            CreateMap<Contact, ContactUpdateVM>().ReverseMap();
        }
    }
}
