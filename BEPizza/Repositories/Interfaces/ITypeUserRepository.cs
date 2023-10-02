using BEPizza.Models;

namespace BEPizza.Repositories.Interfaces
{
    public interface ITypeUserRepository
    {
        IEnumerable<TypeUser> GetAllTypeUser();
        TypeUser GetTypeUserById(string id);
        void AddTypeUser(TypeUser user);
        void UpdateTypeUser(TypeUser user);
        void DeleteTypeUser(string id);
    }
}
