using BEPizza.Models;
using BEPizza.Repositories.Interfaces;
using BEPizza.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BEPizza.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public void AddUser(User user)
        {
            _userRepository.AddUser(user);
        }

        public void DeleteUser(string id)
        {
            try
            {
                _userRepository.DeleteUser(id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<User> GetAllUser()
        {
            return _userRepository.GetAllUser();
        }

        public User GetUserById(string id)
        {
            try
            {
                return _userRepository.GetUserById(id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void UpdateUser(User user)
        {
            try
            {
                _userRepository.UpdateUser(user);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
