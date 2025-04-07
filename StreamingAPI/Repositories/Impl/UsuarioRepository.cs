using StreamingAPI.Data;
using StreamingAPI.Model;

namespace StreamingAPI.Repositories.Impl
{
    public class UsuarioRepository : IRepository<Usuario>
    {
        private readonly AppDbContext _context;

        public UsuarioRepository(AppDbContext context)
        {
            _context = context;
        }

        public List<Usuario> GetAll()
        {
            return _context.Usuarios.ToList();
        }

        public Usuario GetByID(int id)
        {
            return _context.Usuarios.FirstOrDefault(p => p.Id == id);
        }

        public void Add(Usuario entity)
        {
            _context.Usuarios.Add(entity);
            _context.SaveChanges();
        }

        public void Update(Usuario entity)
        {
            _context.Usuarios.Update(entity);
            _context.SaveChanges();
        }
        public void Delete(Usuario entity)
        {
            _context.Usuarios.Remove(entity);
            _context.SaveChanges();
        }

        public Usuario GetByEmailAndPassword(string email, string password)
        {
            return _context.Usuarios.FirstOrDefault(u =>
                u.Email.ToLower() == email.ToLower() &&
                u.Senha == password);
        }
    }
}
