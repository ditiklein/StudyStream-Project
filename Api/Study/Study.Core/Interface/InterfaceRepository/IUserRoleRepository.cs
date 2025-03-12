using Study.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study.Core.Interface.InterfaceRepository
{
    public interface IUserRoleRepository
    {
        Task<UserRole> AddAsync(UserRole userRole);
        Task DeleteAsync(int id);
        IEnumerable<UserRole> GetAll();
        UserRole GetByUserId(int id);
        public UserRole GetById(int id);
        Task<bool> UpdateAsync(int id, UserRole userRole);
}
}
