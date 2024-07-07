using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Сантехник.EntityLayer.Identity;

namespace Сантехник.ServiceLayer.Helpers.Identity.EmailHelper
{
    public interface IEmailSendMethod
    {
        Task SendPasswordResetLinkWithToken(string passwordResetLink, string token);
    }
    public class EmailSendMethod : IEmailSendMethod
    {
        public Task SendPasswordResetLinkWithToken(string passwordResetLink, string token)
        {
             
        }
    }
}
