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
using Сантехник.EntityLayer.WebApplication.ViewModels.PortfolioVM;
using Сантехник.RepositoryLayer.Repositories.Abstract;
using Сантехник.RepositoryLayer.UnitOfWork.Abstract;
using Сантехник.ServiceLayer.Services.Abstract;

namespace Сантехник.ServiceLayer.Services.Concrete
{
    public class PortfolioService : IPortfolioService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IGenericRepositories<Portfolio> _repository;

        public PortfolioService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _repository = _unitOfWork.GetGenericRepository<Portfolio>();
        }



        public async Task<List<PortfolioListVM>> GetAllListAsync()
        {
            List<PortfolioListVM>? portfolioListVM = await _repository.GetAllEntityList().ProjectTo<PortfolioListVM>(_mapper.ConfigurationProvider).ToListAsync();
            return portfolioListVM;
        }

        public async Task<PortfolioUpdateVM> GetCategoryById(int id)
        {
            PortfolioUpdateVM? portfolio = await _repository.Where(x => x.Id == id).ProjectTo<PortfolioUpdateVM>(_mapper.ConfigurationProvider).SingleAsync();
            return portfolio;
        }

        public async Task AddCategoryService(PortfolioAddVM request)
        {
            Portfolio? portfolio = _mapper.Map<Portfolio>(request);
            await _repository.AddEntityAsync(portfolio);
            await _unitOfWork.CommitAsync();
        }

        public async Task UpdateCategoryAsync(PortfolioUpdateVM request)
        {
            Portfolio? portfolio = _mapper.Map<Portfolio>(request);
            _repository.UpdateEntity(portfolio);
            await _unitOfWork.CommitAsync();
        }

        public async Task DeleteCategoryAsync(int id)
        {
            Portfolio? portfolio = await _repository.GetEntityByIdAsync(id);
            _repository.DeleteEntity(portfolio);
            await _unitOfWork.CommitAsync();
        }
    }
}
