using Study.Core.DTOs;
using Study.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study.Core.Interface.IntarfaceService
{
    public interface IUserService
    {
        IEnumerable<UserDTO> GetAllUsers();
        UserDTO GetUserById(int id);
        Task<UserDTO> UpdateUserAsync(int id, UserDTO book);
        Task<UserDTO> AddUserAsync (UserDTO book);
        Task<bool> DeleteUserAsync(int id);
        UserDTO GetUserByEmail(string email);
        string Authenticate(string email, string password);

    }
}
