using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Сантехник.EntityLayer.WebApplication.ViewModels.ContactVM;

namespace Сантехник.ServiceLayer.Services.WebApplication.Abstract
{
    public interface IContactService
    {
        Task AddContactAsync(ContactAddVM request);
        Task DeleteContactAsync(int id);
        Task<List<ContactListVM>> GetAllListAsync();
        Task<ContactUpdateVM> GetContactById(int id);
        Task UpdateContactAsync(ContactUpdateVM request);

        Task<List<ContactListForUI>> GetAllListForUIAsync();
    }
}
