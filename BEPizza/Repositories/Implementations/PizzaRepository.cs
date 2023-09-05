using BEPizza.Models;
using BEPizza.Repositories.Interfaces;

namespace BEPizza.Repositories.Implementations
{
    public class PizzaRepository : IPizzaRepository
    {
        private readonly PizzaContext _dbcontext;

        public PizzaRepository(PizzaContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public void AddPizza(Pizza pizza)
        {
            _dbcontext.Pizza.Add(pizza);
            _dbcontext.SaveChanges();
        }

        public void DeletePizza(string id)
        {
            try
            {
                var pizza = GetPizzaById(id);
                if (pizza != null)
                {
                    _dbcontext.Pizza.Remove(pizza);
                    _dbcontext.SaveChanges();
                }
                else
                {
                    throw new Exception("Can not find PizzaId!");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<Pizza> GetAllPizza()
        {
            return _dbcontext.Pizza.ToList();
        }

        public Pizza GetPizzaById(string id)
        {
            try
            {
                var Pizza = _dbcontext.Pizza.FirstOrDefault(x => x.PizzaID == id);
                if (Pizza != null)
                {
                    return Pizza;
                }
                else
                {
                    throw new Exception("Can not find Pizza!");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void UpdatePizza(Pizza pizza)
        {
            try
            {
                _dbcontext.Pizza.Update(pizza);
                _dbcontext.SaveChanges(true);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
