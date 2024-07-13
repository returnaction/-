using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Сантехник.EntityLayer.WebApplication.Entities;
using Сантехник.EntityLayer.WebApplication.ViewModels.CategoryVM;
using Сантехник.EntityLayer.WebApplication.ViewModels.ContactVM;
using Сантехник.RepositoryLayer.Repositories.Abstract;
using Сантехник.RepositoryLayer.UnitOfWork.Abstract;
using Сантехник.ServiceLayer.Services.WebApplication.Abstract;

namespace Сантехник.ServiceLayer.Services.WebApplication.Concrete
{
    public class ContactService : IContactService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IGenericRepositories<Contact> _repository;

        public ContactService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _repository = _unitOfWork.GetGenericRepository<Contact>();
        }


        public async Task<List<ContactListVM>> GetAllListAsync()
        {
            List<ContactListVM>? contactListVM = await _repository.GetAllEntityList().ProjectTo<ContactListVM>(_mapper.ConfigurationProvider).ToListAsync();
            return contactListVM;
        }

        public async Task<ContactUpdateVM> GetContactById(int id)
        {
            ContactUpdateVM? contact = await _repository.Where(x => x.Id == id).ProjectTo<ContactUpdateVM>(_mapper.ConfigurationProvider).SingleAsync();
            return contact;
        }

        public async Task AddContactAsync(ContactAddVM request)
        {
            Contact? contact = _mapper.Map<Contact>(request);
            await _repository.AddEntityAsync(contact);
            await _unitOfWork.CommitAsync();
        }

        public async Task UpdateContactAsync(ContactUpdateVM request)
        {
            Contact? contact = _mapper.Map<Contact>(request);
            _repository.UpdateEntity(contact);
            await _unitOfWork.CommitAsync();
        }

        public async Task DeleteContactAsync(int id)
        {
            Contact? contact = await _repository.GetEntityByIdAsync(id);
            _repository.DeleteEntity(contact);
            await _unitOfWork.CommitAsync();
        }

        // UI Service methods

        public async Task<List<ContactListForUI>> GetAllListForUIAsync()
        {
            var contactListForUI = await _repository.GetAllEntityList().ProjectTo<ContactListForUI>(_mapper.ConfigurationProvider).ToListAsync();
            return contactListForUI;
        }
    }
}
