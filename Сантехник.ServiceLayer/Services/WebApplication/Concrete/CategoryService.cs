using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Сантехник.EntityLayer.WebApplication.Entities;
using Сантехник.EntityLayer.WebApplication.ViewModels.AboutVM;
using Сантехник.EntityLayer.WebApplication.ViewModels.CategoryVM;
using Сантехник.RepositoryLayer.Repositories.Abstract;
using Сантехник.RepositoryLayer.UnitOfWork.Abstract;
using Сантехник.ServiceLayer.Services.WebApplication.Abstract;

namespace Сантехник.ServiceLayer.Services.WebApplication.Concrete
{
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IGenericRepositories<Category> _repository;

        public CategoryService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _repository = _unitOfWork.GetGenericRepository<Category>();
        }



        public async Task<List<CategoryListVM>> GetAllListAsync()
        {
            List<CategoryListVM>? categoryListVM = await _repository.GetAllEntityList().ProjectTo<CategoryListVM>(_mapper.ConfigurationProvider).ToListAsync();
            return categoryListVM;
        }

        public async Task<CategoryUpdateVM> GetCategoryById(int id)
        {
            CategoryUpdateVM? category = await _repository.Where(x => x.Id == id).ProjectTo<CategoryUpdateVM>(_mapper.ConfigurationProvider).SingleAsync();
            return category;
        }

        public async Task AddCategoryService(CategoryAddVM request)
        {
            Category? category = _mapper.Map<Category>(request);
            await _repository.AddEntityAsync(category);
            await _unitOfWork.CommitAsync();
        }

        public async Task UpdateCategoryAsync(CategoryUpdateVM request)
        {
            Category? category = _mapper.Map<Category>(request);
            _repository.UpdateEntity(category);
            await _unitOfWork.CommitAsync();
        }

        public async Task DeleteCategoryAsync(int id)
        {
            Category? category = await _repository.GetEntityByIdAsync(id);
            _repository.DeleteEntity(category);
            await _unitOfWork.CommitAsync();
        }

    }
}

