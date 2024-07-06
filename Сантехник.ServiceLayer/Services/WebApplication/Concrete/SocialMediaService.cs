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
using Сантехник.EntityLayer.WebApplication.ViewModels.SocialMediaVM;
using Сантехник.RepositoryLayer.Repositories.Abstract;
using Сантехник.RepositoryLayer.UnitOfWork.Abstract;
using Сантехник.ServiceLayer.Services.WebApplication.Abstract;

namespace Сантехник.ServiceLayer.Services.WebApplication.Concrete
{
    public class SocialMediaService : ISocialMediaService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IGenericRepositories<SocialMedia> _repository;

        public SocialMediaService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _repository = _unitOfWork.GetGenericRepository<SocialMedia>();
        }



        public async Task<List<SocialMediaListVM>> GetAllListAsync()
        {
            List<SocialMediaListVM>? socialMediaListVM = await _repository.GetAllEntityList().ProjectTo<SocialMediaListVM>(_mapper.ConfigurationProvider).ToListAsync();
            return socialMediaListVM;
        }

        public async Task<SocialMediaUpdateVM> GetSocialMediaById(int id)
        {
            SocialMediaUpdateVM? socialMedia = await _repository.Where(x => x.Id == id).ProjectTo<SocialMediaUpdateVM>(_mapper.ConfigurationProvider).SingleAsync();
            return socialMedia;
        }

        public async Task AddSocialMediaService(SocialMediaAddVM request)
        {
            SocialMedia? socialMedia = _mapper.Map<SocialMedia>(request);
            await _repository.AddEntityAsync(socialMedia);
            await _unitOfWork.CommitAsync();
        }

        public async Task UpdateSocialMediaAsync(SocialMediaUpdateVM request)
        {
            SocialMedia? socialMedia = _mapper.Map<SocialMedia>(request);
            _repository.UpdateEntity(socialMedia);
            await _unitOfWork.CommitAsync();
        }

        public async Task DeleteSocialMediaAsync(int id)
        {
            SocialMedia? socialMedia = await _repository.GetEntityByIdAsync(id);
            _repository.DeleteEntity(socialMedia);
            await _unitOfWork.CommitAsync();
        }
    }
}
