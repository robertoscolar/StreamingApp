using StreamingAPI.Data;
using StreamingAPI.Model;

namespace StreamingAPI.Repositories.Impl
{
    public class CriadorRepository : IRepository<Criador>
    {
        private readonly AppDbContext _context;

        public CriadorRepository(AppDbContext context)
        {
            _context = context;
        }

        public List<Criador> GetAll()
        {
            return _context.Criadores.ToList();
        }

        public Criador GetByID(int id)
        {
            return _context.Criadores.FirstOrDefault(p => p.Id == id);
        }

        public void Add(Criador entity)
        {
            _context.Criadores.Add(entity);
            _context.SaveChanges();
        }

        public void Update(Criador entity)
        {
            _context.Criadores.Update(entity);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var entity = GetByID(id);

            if (entity != null)
            {
                _context.Criadores.Remove(entity);
                _context.SaveChanges();
            }
        }
    }
}
