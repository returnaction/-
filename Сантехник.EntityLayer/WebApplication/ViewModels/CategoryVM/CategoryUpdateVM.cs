using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Сантехник.EntityLayer.WebApplication.ViewModels.CategoryVM
{
    public class CategoryUpdateVM
    {
        public int Id { get; set; }
        public string? UpdateDate { get; set; }

        public byte[] RowVersion { get; set; } = null!;


        public string Name { get; set; } = null!;
    }
}
