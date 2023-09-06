using BEPizza.Models;

namespace BEPizza.Services.Interfaces
{
    public interface ITypeUserService
    {
        IEnumerable<TypeUser> GetAllTypeUser();
        TypeUser GetTypeUserById(string id);
        void AddTypeUser(TypeUser typeUser);
        void UpdateTypeUser(TypeUser typeUser);
        void DeleteTypeUser(string id);
    }
}
