using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Сантехник.EntityLayer.WebApplication.Entities;
using Сантехник.EntityLayer.WebApplication.ViewModels.TestimonialVM;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Сантехник.ServiceLayer.Automapper.WebApplication
{
    public class TestimonialMapper : Profile
    {
        public TestimonialMapper()
        {
            CreateMap<Testimonial, TestimonialAddVM>().ReverseMap();
            CreateMap<Testimonial, TestimonialListVM>().ReverseMap();
            CreateMap<Testimonial, TestimonialUpdateVM>().ReverseMap();
        }
    }
}
