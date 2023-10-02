using BEPizza.Models;
using BEPizza.Repositories.Interfaces;

namespace BEPizza.Repositories.Implementations
{
    public class SizePizzaRepository : ISizePizzaRepository
    {
        private readonly PizzaContext _dbcontext;

        public SizePizzaRepository(PizzaContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public void AddSizePizza(SizePizza sizePizza)
        {
            _dbcontext.SizePizza.Add(sizePizza);
            _dbcontext.SaveChanges();
        }

        public void DeleteSizePizza(string id)
        {
            try
            {
                var sizePizza = GetSizePizzaById(id);
                if (sizePizza != null)
                {
                    _dbcontext.SizePizza.Remove(sizePizza);
                    _dbcontext.SaveChanges();
                }
                else
                {
                    throw new Exception("Can not find SizePizzaId!");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<SizePizza> GetAllSizePizza()
        {
            return _dbcontext.SizePizza.ToList();
        }

        public SizePizza GetSizePizzaById(string id)
        {
            try
            {
                var SizePizza = _dbcontext.SizePizza.FirstOrDefault(x => x.SizeID == id);
                if (SizePizza != null)
                {
                    return SizePizza;
                }
                else
                {
                    throw new Exception("Can not find SizePizza!");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void UpdateSizePizza(SizePizza SizePizza)
        {
            try
            {
                _dbcontext.SizePizza.Update(SizePizza);
                _dbcontext.SaveChanges(true);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
