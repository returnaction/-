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
using Сантехник.EntityLayer.WebApplication.ViewModels.AboutVM;
using Сантехник.RepositoryLayer.Repositories.Abstract;
using Сантехник.RepositoryLayer.UnitOfWork.Abstract;
using Сантехник.ServiceLayer.Helpers.Generic.Image;
using Сантехник.ServiceLayer.Services.WebApplication.Abstract;

namespace Сантехник.ServiceLayer.Services.WebApplication.Concrete
{
    public class AboutService : IAboutService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IGenericRepositories<About> _repository;
        private readonly IImageHelper _imageHelper;
        public AboutService(IUnitOfWork unitOfWork, IMapper mapper, IImageHelper imageHelper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _repository = _unitOfWork.GetGenericRepository<About>();
            _imageHelper = imageHelper;
        }

        public async Task<List<AboutListVM>> GetAllListAsync()
        {
            List<AboutListVM>? aboutListVM = await _repository.GetAllEntityList().ProjectTo<AboutListVM>
                (_mapper.ConfigurationProvider).ToListAsync();

            return aboutListVM;
        }

        public async Task<AboutUpdateVM> GetAboutById(int id)
        {
            AboutUpdateVM? about = await _repository.Where(x => x.Id == id).ProjectTo<AboutUpdateVM>(_mapper.ConfigurationProvider).SingleAsync();//FirstOrDefaultAsync();
            return about;
        }

        public async Task AddAboutAsync(AboutAddVM request)
        {
            var imageResult = await _imageHelper.ImageUpload(request.Photo, ImageType.about, null);

            if (imageResult.Error != null)
            {
                return;
            }

            request.FileName = imageResult.Filename!;
            request.FileType = imageResult.FileType!;

            About? about = _mapper.Map<About>(request);
            await _repository.AddEntityAsync(about);
            await _unitOfWork.CommitAsync();
        }

        public async Task UpdateAboutAsync(AboutUpdateVM request)
        {
            var imageResult = await _imageHelper.ImageUpload(request.Photo, ImageType.about, null);

            if (imageResult.Error != null)
            {
                return;
            }

            request.FileName = imageResult.Filename!;
            request.FileType = imageResult.FileType!;

            var about = _mapper.Map<About>(request);
            _repository.UpdateEntity(about);
            await _unitOfWork.CommitAsync();

        }

        public async Task DeleteAboutAsync(int id)
        {
            About? about = await _repository.GetEntityByIdAsync(id);
            _repository.DeleteEntity(about);
            await _unitOfWork.CommitAsync();
        }

    }
}
