using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Сантехник.EntityLayer.Identity.Entities;
using Сантехник.EntityLayer.WebApplication.Entities;
using Сантехник.RepositoryLayer.UnitOfWork.Abstract;
using Сантехник.ServiceLayer.Services.WebApplication.Abstract;

namespace Сантехник.ServiceLayer.Services.WebApplication.Concrete
{
    public class DashBoardService : IDashBoardService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<AppUser> _userManager;

        public DashBoardService(IUnitOfWork unitOfWork, UserManager<AppUser> userManager)
        {
            _unitOfWork = unitOfWork;
            _userManager = userManager;
        }

        public async Task<int> GetAllCategoriesCountAsync()
        {
            var categoryCount = await _unitOfWork.GetGenericRepository<Category>().GetAllCount();
            return categoryCount;
        }

        public async Task<int> GetAllPortfoliosCountAsync()
        {
            var portfolioCount = await _unitOfWork.GetGenericRepository<Portfolio>().GetAllCount();
            return portfolioCount;
        }

        public async Task<int> GetAllServicesCountAsync()
        {
            var serviceCount = await _unitOfWork.GetGenericRepository<Service>().GetAllCount();
            return serviceCount;
        }

        public async Task<int> GetAllTeamsCountAsync()
        {
            var teamCount = await _unitOfWork.GetGenericRepository<Team>().GetAllCount();
            return teamCount;
        }

        public async Task<int> GetAllTestimonalsCountAsync()
        {
            var testimonalCount = await _unitOfWork.GetGenericRepository<Testimonial>().GetAllCount();
            return testimonalCount;
        }

        public int GetAllUsersCountAsync()
        {
            var userCount = _userManager.Users.Count();
            return userCount;
        }
    }
}
