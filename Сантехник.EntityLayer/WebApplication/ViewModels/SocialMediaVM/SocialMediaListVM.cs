using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Сантехник.EntityLayer.WebApplication.ViewModels.AboutVM;

namespace Сантехник.EntityLayer.WebApplication.ViewModels.SocialMediaVM
{
    public class SocialMediaListVM
    {
        public int Id { get; set; }
        public string CreatedDate { get; set; } = DateTime.Now.ToString("d");
        public string? UpdateDate { get; set; }


        public string? Twitter { get; set; } = null!;
        public string? Linkedin { get; set; } = null!;
        public string? Facebook { get; set; } = null!;
        public string? Instagram { get; set; } = null!;

        public int AboutUsId { get; set; }
        public AboutListVM About { get; set; } = null!;
    }
}
