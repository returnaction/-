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
using Сантехник.EntityLayer.WebApplication.ViewModels.TeamVM;
using Сантехник.RepositoryLayer.Repositories.Abstract;
using Сантехник.RepositoryLayer.UnitOfWork.Abstract;
using Сантехник.ServiceLayer.Services.Abstract;

namespace Сантехник.ServiceLayer.Services.Concrete
{
    public class TeamService : ITeamService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IGenericRepositories<Team> _repository;

        public TeamService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _repository = _unitOfWork.GetGenericRepository<Team>();
        }



        public async Task<List<TeamListVM>> GetAllListAsync()
        {
            List<TeamListVM>? teamListVM = await _repository.GetAllEntityList().ProjectTo<TeamListVM>(_mapper.ConfigurationProvider).ToListAsync();
            return teamListVM;
        }

        public async Task<TeamUpdateVM> GetCategoryById(int id)
        {
            TeamUpdateVM? team = await _repository.Where(x => x.Id == id).ProjectTo<TeamUpdateVM>(_mapper.ConfigurationProvider).SingleAsync();
            return team;
        }

        public async Task AddCategoryService(TeamAddVM request)
        {
            Team? team = _mapper.Map<Team>(request);
            await _repository.AddEntityAsync(team);
            await _unitOfWork.CommitAsync();
        }

        public async Task UpdateCategoryAsync(TeamUpdateVM request)
        {
            Team? team = _mapper.Map<Team>(request);
            _repository.UpdateEntity(team);
            await _unitOfWork.CommitAsync();
        }

        public async Task DeleteCategoryAsync(int id)
        {
            Team? team = await _repository.GetEntityByIdAsync(id);
            _repository.DeleteEntity(team);
            await _unitOfWork.CommitAsync();
        }
    }
}
