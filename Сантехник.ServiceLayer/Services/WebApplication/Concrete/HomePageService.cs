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
using Сантехник.EntityLayer.WebApplication.ViewModels.HomePageVM;
using Сантехник.RepositoryLayer.Repositories.Abstract;
using Сантехник.RepositoryLayer.UnitOfWork.Abstract;
using Сантехник.ServiceLayer.Services.WebApplication.Abstract;

namespace Сантехник.ServiceLayer.Services.WebApplication.Concrete
{
    public class HomePageService : IHomePageService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IGenericRepositories<HomePage> _repository;

        public HomePageService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _repository = _unitOfWork.GetGenericRepository<HomePage>();
        }



        public async Task<List<HomePageListVM>> GetAllListAsync()
        {
            List<HomePageListVM>? homePageListVM = await _repository.GetAllEntityList().ProjectTo<HomePageListVM>(_mapper.ConfigurationProvider).ToListAsync();
            return homePageListVM;
        }

        public async Task<HomePageUpdateVM> GetHomePageById(int id)
        {
            HomePageUpdateVM? homePage = await _repository.Where(x => x.Id == id).ProjectTo<HomePageUpdateVM>(_mapper.ConfigurationProvider).SingleAsync();
            return homePage;
        }

        public async Task AddHomePageService(HomePageAddVM request)
        {
            HomePage? homePage = _mapper.Map<HomePage>(request);
            await _repository.AddEntityAsync(homePage);
            await _unitOfWork.CommitAsync();
        }

        public async Task UpdateHomePageAsync(HomePageUpdateVM request)
        {
            HomePage? homePage = _mapper.Map<HomePage>(request);
            _repository.UpdateEntity(homePage);
            await _unitOfWork.CommitAsync();
        }

        public async Task DeleteHomePageAsync(int id)
        {
            HomePage? homePage = await _repository.GetEntityByIdAsync(id);
            _repository.DeleteEntity(homePage);
            await _unitOfWork.CommitAsync();
        }


        // UI Service methods

        public async Task<List<HomePageVMForUI>> GetAllListForUI()
        {
            var uiList = await _repository.GetAllEntityList().ProjectTo<HomePageVMForUI>(_mapper.ConfigurationProvider).ToListAsync();
            return uiList;
        }
    }
}
