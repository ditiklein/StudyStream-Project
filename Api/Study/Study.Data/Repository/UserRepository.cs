
using Study.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using Study.Core.Interface.InterfaceRepository;
using System.Threading.Tasks;

namespace Study.Data.Repository
{
    public class UserRepository : IUserRepository
    {
        readonly DataContext _datacontext;

        public UserRepository(DataContext context)
        {
            _datacontext = context;
        }

        public List<User> GetAll()
        {
            return _datacontext.UserList.ToList();
        }

        public async Task<User> AddAsync(User user)
        {
            try
            {
               var User= _datacontext.UserList.Add(user);
                await _datacontext.SaveChangesAsync();
                return user;
            }
            catch
            {
                return null;
            }
        }

        public User? GetById(int id)
        {
            return _datacontext.UserList.Where(u => u.Id == id).FirstOrDefault();
        }
        
        public User? GetByEmail(string email)
         {
            return _datacontext.UserList.FirstOrDefault(u => u.Email == email);
        }


        public int GetIndexById(int id)
        {
            return _datacontext.UserList.ToList().FindIndex(u => u.Id == id);
        }

        public async Task<User> UpdateAsync(User user, int id)
        {

            var existingUser = _datacontext.UserList.FirstOrDefault(c => c.Id == id);
            if (existingUser == null) return null;



            existingUser.FirstName = user.FirstName;
            existingUser.LastName = user.LastName;
            existingUser.Password = user.Password;
            existingUser.Email = user.Email;
            existingUser.UpdateBy = user.UpdateBy;
            existingUser.UpdateAt = DateTime.Now;

            try
            {
               await _datacontext.SaveChangesAsync();
                return user;
            }
            catch
            {
                return null;
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var user = _datacontext.UserList.FirstOrDefault(c => c.Id == id);
            if (user == null) return false;
            try
            {
                _datacontext.UserList.Remove(user);
               await _datacontext.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
