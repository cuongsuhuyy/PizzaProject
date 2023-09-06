using BEPizza.Models;
using BEPizza.Repositories.Interfaces;
using BEPizza.Services.Interfaces;

namespace BEPizza.Services.Implementations
{
    public class TypeUserService : ITypeUserService
    {
        private readonly ITypeUserRepository _typeUserRepository;

        public TypeUserService(ITypeUserRepository typeUserRepository)
        {
            _typeUserRepository = typeUserRepository;
        }

        public void AddTypeUser(TypeUser typeUser)
        {
            _typeUserRepository.AddTypeUser(typeUser);
        }

        public void DeleteTypeUser(string id)
        {
            try
            {
                _typeUserRepository.DeleteTypeUser(id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<TypeUser> GetAllTypeUser()
        {
            return _typeUserRepository.GetAllTypeUser();
        }

        public TypeUser GetTypeUserById(string id)
        {
            try
            {
                return _typeUserRepository.GetTypeUserById(id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void UpdateTypeUser(TypeUser TypeUser)
        {
            try
            {
                _typeUserRepository.UpdateTypeUser(TypeUser);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
