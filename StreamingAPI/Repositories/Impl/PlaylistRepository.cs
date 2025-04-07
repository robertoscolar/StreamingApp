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
            return _context.Playlists.ToList();
        }
       
        public Playlist GetByID(int id)
        {
            return _context.Playlists.FirstOrDefault(p => p.Id == id);
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

        public void Delete(Playlist entity)
        {
            _context.Playlists.Remove(entity);
            _context.SaveChanges();
        }
    }
}
