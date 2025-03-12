using Microsoft.EntityFrameworkCore;
using Study.Core.Entities;
using Study.Core.Interface.InterfaceRepository;
using Study.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayArt.Data.Repositories
{
    public class UserRoleRepository : IUserRoleRepository
    {
        protected readonly DataContext _dataContext;

        public UserRoleRepository(DataContext context)
        {
            _dataContext = context; // Assuming your DataContext has a DbSet<UserRole> property
        }

        public  async Task<UserRole> AddAsync(UserRole userRole)
        {
             _dataContext.UserRoles.AddAsync(userRole);
             await _dataContext.SaveChangesAsync();
             return userRole;
        }

        public async Task DeleteAsync(int id)
        {
            var userRole =  GetById(id);
              _dataContext.UserRoles.Remove(userRole);
            await _dataContext.SaveChangesAsync();
        }

        public  IEnumerable<UserRole> GetAll()
        {
            return _dataContext.UserRoles.Include(ur => ur.User).Include(ur => ur.Role).ToList();
        }

        public  UserRole GetByUserId(int id)
        {
            return _dataContext.UserRoles.Include(ur => ur.User).Include(ur => ur.Role).FirstOrDefault(ur => ur.UserId == id);
        }
        public  UserRole GetById(int id)
        {
            return _dataContext.UserRoles.Include(ur => ur.User).Include(ur => ur.Role).FirstOrDefault(ur => ur.Id == id);
        }
        public async Task<bool> UpdateAsync(int id, UserRole userRole)
        {
            UserRole existingUserRole = GetById(id);
            if (existingUserRole != null)
            {
                existingUserRole.UserId = userRole.UserId;
                existingUserRole.RoleId = userRole.RoleId;
                await _dataContext.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
