using BEPizza.Models;
using BEPizza.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BEPizza.Repositories.Implementations
{
    public class UserRepository : IUserRepository
    {
        private readonly PizzaContext _dbcontext;

        public UserRepository(PizzaContext dbContext)
        {
            _dbcontext = dbContext;
        }

        public void AddUser(User user)
        {
            _dbcontext.User.Add(user);
            _dbcontext.SaveChanges();
        }

        public void DeleteUser(string id)
        {
            try
            {
                var user = GetUserById(id);
                if (user != null)
                {
                    _dbcontext.User.Remove(user);
                    _dbcontext.SaveChanges();
                }
                else
                {
                    throw new Exception("Can not find userId!");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<User> GetAllUser()
        {
            return _dbcontext.User.ToList();
        }

        public User GetUserById(string id)
        {
            try
            {
                var user = _dbcontext.User.FirstOrDefault(x => x.UserID == id);
                if (user != null)
                {
                    return user;
                }
                else
                {
                    throw new Exception("Can not find User!");
                }
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
                _dbcontext.User.Update(user);
                _dbcontext.SaveChanges(true);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
