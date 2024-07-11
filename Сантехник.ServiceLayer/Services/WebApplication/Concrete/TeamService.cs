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
using Сантехник.EntityLayer.WebApplication.ViewModels.TeamVM;
using Сантехник.RepositoryLayer.Repositories.Abstract;
using Сантехник.RepositoryLayer.UnitOfWork.Abstract;
using Сантехник.ServiceLayer.Helpers.Generic.Image;
using Сантехник.ServiceLayer.Services.WebApplication.Abstract;

namespace Сантехник.ServiceLayer.Services.WebApplication.Concrete
{
    public class TeamService : ITeamService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IGenericRepositories<Team> _repository;
        private readonly IImageHelper _imageHelper;

        public TeamService(IUnitOfWork unitOfWork, IMapper mapper, IImageHelper imageHelper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _repository = _unitOfWork.GetGenericRepository<Team>();
            _imageHelper = imageHelper;
        }



        public async Task<List<TeamListVM>> GetAllListAsync()
        {
            List<TeamListVM>? teamListVM = await _repository.GetAllEntityList().ProjectTo<TeamListVM>(_mapper.ConfigurationProvider).ToListAsync();
            return teamListVM;
        }

        public async Task<TeamUpdateVM> GetTeamById(int id)
        {
            TeamUpdateVM? team = await _repository.Where(x => x.Id == id).ProjectTo<TeamUpdateVM>(_mapper.ConfigurationProvider).SingleAsync();
            return team;
        }

        public async Task AddTeamService(TeamAddVM request)
        {

            var imageResult = await _imageHelper.ImageUpload(request.Photo, ImageType.team, null);

            if (imageResult.Error != null)
            {
                return;
            }

            request.FileName = imageResult.Filename!;
            request.FileType = imageResult.FileType!;

            Team? team = _mapper.Map<Team>(request);
            await _repository.AddEntityAsync(team);
            await _unitOfWork.CommitAsync();
        }

        public async Task UpdateTeamAsync(TeamUpdateVM request)
        {
            var imageResult = await _imageHelper.ImageUpload(request.Photo, ImageType.team, null);

            if (imageResult.Error != null)
            {
                return;
            }

            request.FileName = imageResult.Filename!;
            request.FileType = imageResult.FileType!;

            Team? team = _mapper.Map<Team>(request);
            _repository.UpdateEntity(team);
            await _unitOfWork.CommitAsync();
        }

        public async Task DeleteTeamAsync(int id)
        {
            Team? team = await _repository.GetEntityByIdAsync(id);
            _repository.DeleteEntity(team);
            await _unitOfWork.CommitAsync();

            _imageHelper.DeleteImage(team.FileName);
        }

        // UI Service methods

        public async Task<List<TeamListForUI>> GetAllListForUIAsync()
        {
            var teamListForUI = await _repository.GetAllEntityList().ProjectTo<TeamListForUI>(_mapper.ConfigurationProvider).ToListAsync();
            return teamListForUI;
        }
    }
}
