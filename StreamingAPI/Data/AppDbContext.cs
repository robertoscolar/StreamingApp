using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using StreamingAPI.Model;

namespace StreamingAPI.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Playlist> Playlists { get; set; }
        public DbSet<Conteudo> Conteudos { get; set; }
        public DbSet<Criador> Criadores { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ItemPlaylist>()
                .HasKey(ip => new { ip.PlaylistId, ip.ConteudoId });
        }
    }  
}
