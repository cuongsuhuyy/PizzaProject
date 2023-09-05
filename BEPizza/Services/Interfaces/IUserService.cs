using BEPizza.Models;

namespace BEPizza.Services.Interfaces
{
    public interface IUserService
    {
        IEnumerable<User> GetAllUser();
        User GetUserById(string id);
        void AddUser(User user);
        void UpdateUser(User user);
        void DeleteUser(string id);
    }
}
