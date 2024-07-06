using Microsoft.AspNetCore.Mvc;
using Сантехник.EntityLayer.WebApplication.ViewModels.ContactVM;
using Сантехник.ServiceLayer.Services.Abstract;

namespace Сантехник.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ContactController : Controller
    {
        private readonly IContactService _contactService;

        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }

        
        public async Task<IActionResult> GetContactList()
        {
            var contactList = await _contactService.GetAllListAsync();
            return View(contactList);
        }

        public IActionResult AddContact()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddContact(ContactAddVM request)
        {
            await _contactService.AddContactAsync(request);
            return RedirectToAction("GetContactList", "Contact", new { Area = ("Admin") });
        }

        public async Task<IActionResult> UpdateContact(int id)
        {
            var contact = await _contactService.GetContactById(id);
            return View(contact);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateContact(ContactUpdateVM request)
        {
            await _contactService.UpdateContactAsync(request);
            return RedirectToAction("GetContactList", "Contact", new { Area = ("Admin") });
        }

        public async Task<IActionResult> DeleteContact(int id)
        {
            await _contactService.DeleteContactAsync(id);
            return RedirectToAction("GetContactList", "Contact", new { Area = ("Admin") });
        }
    }
}
