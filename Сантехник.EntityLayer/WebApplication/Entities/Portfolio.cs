
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Сантехник.CoreLayer.BaseEntity;

namespace Сантехник.EntityLayer.WebApplication.Entities
{
    public class Portfolio : BaseEntity
    {
        public string Title { get; set; } = null!;

        public string FileName { get; set; } = null!;
        public string TyleType { get; set; } = null!;

        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
