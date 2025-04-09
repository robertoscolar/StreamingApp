using Microsoft.EntityFrameworkCore;
using StreamingAPI.Data;
using StreamingAPI.Model;

namespace StreamingAPI.Repositories.Impl
{
    public class PlaylistRepository : IRepository<Playlist>
    {
        private readonly AppDbContext _context;

        public PlaylistRepository(AppDbContext context)
        {
            _context = context;
        }

        public List<Playlist> GetAll()
        {
            return _context.Playlists
                .Include(p => p.ItensPlaylist)
                    .ThenInclude(ip => ip.Conteudo)
                        .ThenInclude(c => c.Criador)
                .Include(p => p.Usuario)
                .ToList();
        }
       
        public Playlist GetByID(int id)
        {
            return _context.Playlists
                .Include(p => p.ItensPlaylist)
                    .ThenInclude(ip => ip.Conteudo)
                        .ThenInclude(c => c.Criador)
                .Include(p => p.Usuario)
                .FirstOrDefault(p => p.Id == id);
        }

        public void Add(Playlist entity)
        {
            _context.Playlists.Add(entity);
            _context.SaveChanges();
        }

        public void Update(Playlist entity)
        {
            _context.Playlists.Update(entity);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var entity = GetByID(id);

            if (entity != null)
            {
                _context.Set<ItemPlaylist>().RemoveRange(entity.ItensPlaylist);
                _context.Playlists.Remove(entity);
                _context.SaveChanges();
            }
        }
    }
}
