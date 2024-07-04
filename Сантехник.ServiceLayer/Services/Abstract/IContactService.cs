using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Сантехник.EntityLayer.WebApplication.ViewModels.ContactVM;

namespace Сантехник.ServiceLayer.Services.Abstract
{
    public interface IContactService
    {
        Task AddCategoryService(ContactAddVM request);
        Task DeleteCategoryAsync(int id);
        Task<List<ContactListVM>> GetAllListAsync();
        Task<ContactUpdateVM> GetCategoryById(int id);
        Task UpdateCategoryAsync(ContactUpdateVM request);
    }
}
