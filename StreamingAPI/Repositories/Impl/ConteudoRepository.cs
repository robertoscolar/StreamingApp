using StreamingAPI.Data;
using StreamingAPI.Model;

namespace StreamingAPI.Repositories.Impl
{
    public class ConteudoRepository : IRepository<Conteudo>
    {
        private readonly AppDbContext _context;

        public ConteudoRepository(AppDbContext context)
        {
            _context = context;
        }

        public List<Conteudo> GetAll()
        {
            return _context.Conteudos.ToList();
        }

        public Conteudo GetByID(int id)
        {
            return _context.Conteudos.FirstOrDefault(p => p.Id == id);
        }

        public void Add(Conteudo entity)
        {
            _context.Conteudos.Add(entity);
            _context.SaveChanges();
        }

        public void Update(Conteudo entity)
        {
            _context.Conteudos.Update(entity);
            _context.SaveChanges();
        }

        public void Delete(Conteudo entity)
        {
            _context.Conteudos.Remove(entity);
            _context.SaveChanges();
        }
    }
}
