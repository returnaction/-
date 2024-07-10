using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Сантехник.EntityLayer.Identity.ViewModels
{
    public class UserVM
    {
        public string UserName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public List<string>? UserRoles { get; set; } 
    }
}
