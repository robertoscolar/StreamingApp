using Microsoft.EntityFrameworkCore;
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
            return _context.Conteudos
                .Include(p => p.Criador)
                .ToList();
        }

        public Conteudo GetByID(int id)
        {
            return _context.Conteudos
                .Include(p => p.Criador)
                .FirstOrDefault(p => p.Id == id);
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

        public void Delete(int id)
        {
            var entity = GetByID(id);

            if (entity != null)
            {
                _context.Conteudos.Remove(entity);
                _context.SaveChanges();
            }
        }
    }
}
