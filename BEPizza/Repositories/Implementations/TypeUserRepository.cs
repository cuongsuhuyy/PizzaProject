using BEPizza.Models;
using BEPizza.Repositories.Interfaces;

namespace BEPizza.Repositories.Implementations
{
    public class TypeUserRepository : ITypeUserRepository
    {
        private readonly PizzaContext _dbcontext;

        public TypeUserRepository(PizzaContext dbContext)
        {
            _dbcontext = dbContext;
        }

        public void AddTypeUser(TypeUser typeUser)
        {
            _dbcontext.TypeUser.Add(typeUser);
            _dbcontext.SaveChanges();
        }

        public void DeleteTypeUser(string id)
        {
            try
            {
                var TypeUser = GetTypeUserById(id);
                if (TypeUser != null)
                {
                    _dbcontext.TypeUser.Remove(TypeUser);
                    _dbcontext.SaveChanges();
                }
                else
                {
                    throw new Exception("Can not find TypeUserId!");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<TypeUser> GetAllTypeUser()
        {
            return _dbcontext.TypeUser.ToList();
        }

        public TypeUser GetTypeUserById(string id)
        {
            try
            {
                var TypeUser = _dbcontext.TypeUser.FirstOrDefault(x => x.TypeID == id);
                if (TypeUser != null)
                {
                    return TypeUser;
                }
                else
                {
                    throw new Exception("Can not find TypeUser!");
                }
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
                _dbcontext.TypeUser.Update(TypeUser);
                _dbcontext.SaveChanges(true);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
