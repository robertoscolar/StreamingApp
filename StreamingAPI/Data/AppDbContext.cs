﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using StreamingAPI.Model;

namespace StreamingAPI.Data
{
    public class AppDbContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public DbSet<User> Users { get; set; }
        public DbSet<Playlist> Playlists { get; set; }
        public DbSet<Content> Contents { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options, IConfiguration configuration)
            : base(options)
        {
        }
    }  
}
