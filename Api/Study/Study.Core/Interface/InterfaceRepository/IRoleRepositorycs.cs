using Study.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study.Core.Interface.InterfaceRepository
{
    public interface IRoleRepositorycs
    {
        IEnumerable<Role> GetAll();
        public Role GetRoleById(int id);
        public Role GetIdByRole(string role);
        public Task<Role> AddAsync(Role role);
        public Task<bool> UpdateAsync(int id, Role role);
        Task DeleteAsync(int id);
    }
}
