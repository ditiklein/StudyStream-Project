using Microsoft.EntityFrameworkCore;
using Study.Core.Entities;
using Study.Core.Interface.InterfaceRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study.Data.Repository
{
    public class RoleRepository:IRoleRepositorycs
    {
        readonly DataContext _datacontext;

        public RoleRepository(DataContext context)
        {
            _datacontext = context;
        }

        public async Task<Role> AddAsync(Role role)
        {
            await _datacontext.AddAsync(role);
            role.CreatedAt = DateTime.UtcNow;
            await _datacontext.SaveChangesAsync();

            return role;
        }

        public async Task DeleteAsync(int id)
        {
            var role =  GetRoleById(id);
            _datacontext.Roles.Remove(role);
            await _datacontext.SaveChangesAsync();

        }
        public IEnumerable<Role> GetAll()
        {
            return  _datacontext.Roles.ToList();
        }

        public Role GetRoleById(int id)
        {
            return _datacontext.Roles.Find(id);
        }
        public  Role GetIdByRole(string role)
        {
            var r =  _datacontext.Roles.FirstOrDefault(r => r.RoleName == role);
            return r;
        }

        public async Task<bool> UpdateAsync(int id, Role role)
        {
            Role existingRole =  GetRoleById(id);
            if (existingRole != null)
            {
                existingRole.RoleName = role.RoleName;
                existingRole.Description = role.Description;
                existingRole.UpdatedAt = DateTime.UtcNow;
                await _datacontext.SaveChangesAsync();

                return true;
            }
            return false;
        }
    }
}
