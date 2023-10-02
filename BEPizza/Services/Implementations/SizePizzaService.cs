using BEPizza.Models;
using BEPizza.Repositories.Interfaces;
using BEPizza.Services.Interfaces;

namespace BEPizza.Services.Implementations
{
    public class SizePizzaService : ISizePizzaService
    {
        private readonly ISizePizzaRepository _sizePizzaRepository;

        public SizePizzaService(ISizePizzaRepository sizePizzaRepository)
        {
            _sizePizzaRepository = sizePizzaRepository;
        }

        public void AddSizePizza(SizePizza sizePizza)
        {
            _sizePizzaRepository.AddSizePizza(sizePizza);
        }

        public void DeleteSizePizza(string id)
        {
            try
            {
                _sizePizzaRepository.DeleteSizePizza(id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<SizePizza> GetAllSizePizza()
        {
            return _sizePizzaRepository.GetAllSizePizza();
        }

        public SizePizza GetSizePizzaById(string id)
        {
            try
            {
                return _sizePizzaRepository.GetSizePizzaById(id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void UpdateSizePizza(SizePizza sizePizza)
        {
            try
            {
                _sizePizzaRepository.UpdateSizePizza(sizePizza);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
