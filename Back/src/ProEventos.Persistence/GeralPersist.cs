using ProEventos.Persistence.Contextos;
using ProEventos.Persistence.Contratos;

namespace ProEventos.Persistence
{
    public class GeralPersist : IGeralPersist
    {
        private readonly ProEventosContext _context;
        public GeralPersist(ProEventosContext context)
        {
            this._context = context;
        }
        public void Add<T>(T entity) where T : class
        {
            this._context.Add(entity);
        }
        public void Update<T>(T entity) where T : class
        {
            this._context.Update(entity);
        }
        public void Delete<T>(T entity) where T : class
        {
            this._context.Remove(entity);
        }
        public void DeleteRange<T>(T[] entityArray) where T : class
        {
           this._context.RemoveRange(entityArray);
        }
        public async Task<bool> SaveChangesAsync()
        {       
              return (await this._context.SaveChangesAsync()) > 0;
        }
       
    }
}