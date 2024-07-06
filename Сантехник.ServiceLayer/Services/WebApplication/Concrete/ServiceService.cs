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
using Сантехник.EntityLayer.WebApplication.ViewModels.ServiceVM;
using Сантехник.RepositoryLayer.Repositories.Abstract;
using Сантехник.RepositoryLayer.UnitOfWork.Abstract;
using Сантехник.ServiceLayer.Services.WebApplication.Abstract;

namespace Сантехник.ServiceLayer.Services.WebApplication.Concrete
{
    public class ServiceService : IServiceService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IGenericRepositories<Service> _repository;

        public ServiceService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _repository = _unitOfWork.GetGenericRepository<Service>();
        }



        public async Task<List<ServiceListVM>> GetAllListAsync()
        {
            List<ServiceListVM>? serviceListVM = await _repository.GetAllEntityList().ProjectTo<ServiceListVM>(_mapper.ConfigurationProvider).ToListAsync();
            return serviceListVM;
        }

        public async Task<ServiceUpdateVM> GetServiceById(int id)
        {
            ServiceUpdateVM? service = await _repository.Where(x => x.Id == id).ProjectTo<ServiceUpdateVM>(_mapper.ConfigurationProvider).SingleAsync();
            return service;
        }

        public async Task AddServiceService(ServiceAddVM request)
        {
            Service? service = _mapper.Map<Service>(request);
            await _repository.AddEntityAsync(service);
            await _unitOfWork.CommitAsync();
        }

        public async Task UpdateServiceAsync(ServiceUpdateVM request)
        {
            Service? service = _mapper.Map<Service>(request);
            _repository.UpdateEntity(service);
            await _unitOfWork.CommitAsync();
        }

        public async Task DeleteServiceAsync(int id)
        {
            Service? service = await _repository.GetEntityByIdAsync(id);
            _repository.DeleteEntity(service);
            await _unitOfWork.CommitAsync();
        }
    }
}
