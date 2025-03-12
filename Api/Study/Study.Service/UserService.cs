using AutoMapper;
using Study.Core.DTOs;
using Study.Core.Entities;
using Study.Core.Interface.IntarfaceService;
using Study.Core.Interface.InterfaceRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study.Service
{

    public class UserService : IUserService
    {
        readonly IUserRepository _userRepository;
        readonly IMapper _mapper;
        readonly IRoleRepositorycs _roleRpository;
        readonly IUserRoleRepository _userRolesRepository;



        public UserService(IUserRepository userRepository, IMapper mapper, IRoleRepositorycs roleRpository, IUserRoleRepository userRolesRepository)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _roleRpository = roleRpository;
            _userRolesRepository = userRolesRepository;
        }

        public IEnumerable<UserDTO> GetAllUsers()
        {
            var users = _userRepository.GetAll();
            return _mapper.Map<IEnumerable<UserDTO>>(users);
        }

        public UserDTO GetUserById(int id)
        {
            var user = _userRepository.GetById(id);
            return _mapper.Map<UserDTO>(user);
        }
        public UserDTO GetUserByEmail(string email)
        {
            var user = _userRepository.GetByEmail(email);
            return _mapper.Map<UserDTO>(user);
        }

        public async Task<UserDTO> UpdateUserAsync(int id, UserDTO userDTO)
        {

            if (id < 0)
                return null;
            var user = _mapper.Map<User>(userDTO);
            var result = await _userRepository.UpdateAsync(user, id);
            return _mapper.Map<UserDTO>(result);

        }

        public async Task<UserDTO> AddUserAsync(UserDTO userDTO)
        {
            var user = _mapper.Map<User>(userDTO);
            if (_userRepository.GetById(user.Id) == null)
            {
                var createdUser = await _userRepository.AddAsync(user);
                return _mapper.Map<UserDTO>(createdUser);
            }
            return null;
        }

        public async Task<bool> DeleteUserAsync(int id)
        {

            if (id < 0) return false;

            await _userRepository.DeleteAsync(id);
            return true;
        }
        public string Authenticate(string email, string password)
        {
            User user = _userRepository.GetByEmail(email);
            if (user == null || !user.Password.Equals(password))
            {
                return null;
            }
            var userRole = _userRolesRepository.GetByUserId(user.Id);
            if (userRole == null)
                return null;

            return userRole.Role.RoleName;
        }


    }

}

