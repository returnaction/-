using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Сантехник.CoreLayer.BaseEntity;

namespace Сантехник.EntityLayer.WebApplication.Entities
{
    public class Category : BaseEntity
    {
        public string Name { get; set; } = null!;

        List<Portfolio> Portfolios { get; set; } = null!;
    }
}
