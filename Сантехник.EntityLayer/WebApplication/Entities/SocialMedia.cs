﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Сантехник.CoreLayer.BaseEntity;

namespace Сантехник.EntityLayer.WebApplication.Entities
{
    public class SocialMedia : BaseEntity
    {
        public string? Twitter { get; set; } = null!;
        public string? Linkedin { get; set; } = null!;
        public string? Facebook { get; set; } = null!;
        public string? Instagram { get; set; } = null!;

        public int AboutUsId { get; set; }
        public AboutUs AboutUs { get; set; }

    }
}
