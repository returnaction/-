using Microsoft.AspNetCore.Mvc;
using Сантехник.ServiceLayer.Services.WebApplication.Abstract;

namespace Сантехник.Components
{
    public class ContactViewComponent: ViewComponent
    {
        private readonly IContactService _contactService;

        public ContactViewComponent(IContactService contactService)
        {
            _contactService = contactService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var contactListForUI = await _contactService.GetAllListForUIAsync();
            return View(contactListForUI);
        }

    }
}
