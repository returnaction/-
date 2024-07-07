using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Сантехник.ServiceLayer.Messages.WebApplication
{
    public static class ValidationMessages
    {
        public static string NullEmptyMessage(string propName)
        {
            return $"{propName} must have a value!";
        }

        public static string MaximumCharacterAllowance(string propName, int restriction)
        {
            return $"{propName} can have maximum of {restriction} characters!";
        }

        public static string GreaterThenMessage(string propName, int restriction)
        {
            return $"{propName} must be grater then {restriction}!";
        }
    }
}
