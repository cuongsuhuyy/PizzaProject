using BEPizza.Models;

namespace BEPizza.Repositories.Interfaces
{
    public interface ISizePizzaRepository
    {
        IEnumerable<SizePizza> GetAllSizePizza();
        SizePizza GetSizePizzaById(string id);
        void AddSizePizza(SizePizza sizePizza);
        void UpdateSizePizza(SizePizza sizePizza);
        void DeleteSizePizza(string id);
    }
}
