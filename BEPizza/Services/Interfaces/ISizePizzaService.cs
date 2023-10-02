using BEPizza.Models;

namespace BEPizza.Services.Interfaces
{
    public interface ISizePizzaService
    {
        IEnumerable<SizePizza> GetAllSizePizza();
        SizePizza GetSizePizzaById(string id);
        void AddSizePizza(SizePizza sizePizza);
        void UpdateSizePizza(SizePizza sizePizza);
        void DeleteSizePizza(string id);
    }
}
