using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using Сантехник.CoreLayer.BaseEntity;

namespace Сантехник.EntityLayer.WebApplication.Entities
{
    public class AboutUs : BaseEntity
    {
        public string Header { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string Clients { get; set; } = null!;
        public string Projects { get; set; } = null!;
        public string HardWorkers { get; set; } = null!;
        public string HoursOfSupport { get; set; } = null!;

        public string FileName { get; set; } = null!;
        public string TyleType { get; set; } = null!;

        public int SocialMediaId { get; set; }
        public SocialMedia SocialMedia { get; set; } = null!;
    }
}
