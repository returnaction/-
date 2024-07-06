using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Сантехник.EntityLayer.WebApplication.ViewModels.TestimonialVM
{
    public class TestimonialListVM
    {
        public int Id { get; set; }
        public string CreatedDate { get; set; } = DateTime.Now.ToString("d");
        public string? UpdateDate { get; set; }


        public string Comment { get; set; } = null!;
        public string FullName { get; set; } = null!;
        public string Title { get; set; } = null!;


        // we probably won't need those in List
        public string FileName { get; set; } = null!;
        public string FileType { get; set; } = null!;
    }
}
