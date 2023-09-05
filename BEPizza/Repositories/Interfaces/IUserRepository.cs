using BEPizza.Models;

namespace BEPizza.Repositories.Interfaces
{
    public interface IUserRepository
    {
        IEnumerable<User> GetAllUser();
        User GetUserById(string id);
        void AddUser(User user);
        void UpdateUser(User user);
        void DeleteUser(string id);
    }
}
