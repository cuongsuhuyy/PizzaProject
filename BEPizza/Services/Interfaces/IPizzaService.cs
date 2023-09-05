using BEPizza.Models;

namespace BEPizza.Services.Interfaces
{
    public interface IPizzaService
    {
        IEnumerable<Pizza> GetAllPizza();
        Pizza GetPizzaById(string id);
        void AddPizza(Pizza pizza);
        void UpdatePizza(Pizza pizza);
        void DeletePizza(string id);
    }
}
