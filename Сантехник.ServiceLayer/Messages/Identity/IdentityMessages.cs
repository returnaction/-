using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Сантехник.ServiceLayer.Messages.Identity
{
    public static class IdentityMessages
    {
        public static string CheckEmailAddress()
        {
            return $"Value should be in email format!";
        }

        public static string ComparePassword()
        {
            return $"Password and Confirm Password must be the same";
        }
    }
}
