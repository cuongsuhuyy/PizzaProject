using BEPizza.Models;
using BEPizza.Repositories.Interfaces;
using BEPizza.Services.Interfaces;

namespace BEPizza.Services.Implementations
{
    public class PizzaService : IPizzaService
    {
        private readonly IPizzaRepository _pizzaRepository;

        public PizzaService(IPizzaRepository pizzaRepository)
        {
            _pizzaRepository = pizzaRepository;
        }

        public void AddPizza(Pizza pizza)
        {
            _pizzaRepository.AddPizza(pizza);
        }

        public void DeletePizza(string id)
        {
            try
            {
                _pizzaRepository.DeletePizza(id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<Pizza> GetAllPizza()
        {
            return _pizzaRepository.GetAllPizza();
        }

        public Pizza GetPizzaById(string id)
        {
            try
            {
                return _pizzaRepository.GetPizzaById(id);
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
                _pizzaRepository.UpdatePizza(pizza);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
