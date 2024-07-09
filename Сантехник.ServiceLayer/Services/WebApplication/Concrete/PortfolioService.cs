using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Сантехник.CoreLayer.Enumerators;
using Сантехник.EntityLayer.WebApplication.Entities;
using Сантехник.EntityLayer.WebApplication.ViewModels.CategoryVM;
using Сантехник.EntityLayer.WebApplication.ViewModels.PortfolioVM;
using Сантехник.RepositoryLayer.Repositories.Abstract;
using Сантехник.RepositoryLayer.UnitOfWork.Abstract;
using Сантехник.ServiceLayer.Helpers.Generic.Image;
using Сантехник.ServiceLayer.Services.WebApplication.Abstract;

namespace Сантехник.ServiceLayer.Services.WebApplication.Concrete
{
    public class PortfolioService : IPortfolioService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IGenericRepositories<Portfolio> _repository;
        private readonly IImageHelper _imageHelper;

        public PortfolioService(IUnitOfWork unitOfWork, IMapper mapper, IImageHelper imageHelper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _repository = _unitOfWork.GetGenericRepository<Portfolio>();
            _imageHelper = imageHelper;
        }



        public async Task<List<PortfolioListVM>> GetAllListAsync()
        {
            List<PortfolioListVM>? portfolioListVM = await _repository.GetAllEntityList().ProjectTo<PortfolioListVM>(_mapper.ConfigurationProvider).ToListAsync();
            return portfolioListVM;
        }

        public async Task<PortfolioUpdateVM> GetPortfolioById(int id)
        {
            PortfolioUpdateVM? portfolio = await _repository.Where(x => x.Id == id).ProjectTo<PortfolioUpdateVM>(_mapper.ConfigurationProvider).SingleAsync();
            return portfolio;
        }

        public async Task AddPortfolioService(PortfolioAddVM request)
        {
            var imageResult = await _imageHelper.ImageUpload(request.Photo, ImageType.portfolio, null);

            if (imageResult.Error != null)
            {
                return;
            }

            request.FileName = imageResult.Filename!;
            request.FileType = imageResult.FileType!;

            Portfolio? portfolio = _mapper.Map<Portfolio>(request);
            await _repository.AddEntityAsync(portfolio);
            await _unitOfWork.CommitAsync();
        }

        public async Task UpdatePortfolioAsync(PortfolioUpdateVM request)
        {
            var imageResult = await _imageHelper.ImageUpload(request.Photo, ImageType.portfolio, null);

            if (imageResult.Error != null)
            {
                return;
            }

            request.FileName = imageResult.Filename!;
            request.FileType = imageResult.FileType!;


            Portfolio? portfolio = _mapper.Map<Portfolio>(request);
            _repository.UpdateEntity(portfolio);
            await _unitOfWork.CommitAsync();
        }

        public async Task DeletePortfolioAsync(int id)
        {
            Portfolio? portfolio = await _repository.GetEntityByIdAsync(id);
            _repository.DeleteEntity(portfolio);
            await _unitOfWork.CommitAsync();

            _imageHelper.DeleteImage(portfolio.FileName);
        }
    }
}
