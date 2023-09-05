using BEPizza.Models;

namespace BEPizza.Repositories.Interfaces
{
    public interface IPizzaRepository
    {
        IEnumerable<Pizza> GetAllPizza();
        Pizza GetPizzaById(string id);
        void AddPizza(Pizza pizza);
        void UpdatePizza(Pizza pizza);
        void DeletePizza(string id);
    }
}
