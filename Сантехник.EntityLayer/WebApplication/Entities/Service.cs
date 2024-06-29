using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Сантехник.CoreLayer.BaseEntity;

namespace Сантехник.EntityLayer.WebApplication.Entities
{
    public class Service : BaseEntity
    {
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string Icon { get; set; } = null!;

    }
}
