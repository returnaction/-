using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Сантехник.EntityLayer.WebApplication.Entities;
using Сантехник.EntityLayer.WebApplication.ViewModels.AboutVM;

namespace Сантехник.EntityLayer.WebApplication.ViewModels.SocialMediaVM
{
    public class SocialMediaAddVM
    {
        public string? Twitter { get; set; } = null!;
        public string? Linkedin { get; set; } = null!;
        public string? Facebook { get; set; } = null!;
        public string? Instagram { get; set; } = null!;

        public int AboutUsId { get; set; }
        public AboutAddVM About { get; set; } = null!;
    }
}
