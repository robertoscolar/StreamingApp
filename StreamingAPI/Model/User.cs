﻿using System.ComponentModel.DataAnnotations;

namespace StreamingAPI.Model
{
    public class User
    {
        [Key]
        public int ID { get; set; }

        public string? Name { get; set; }

        public string? Email { get; set; }

        public string? Password { get; set; }

        public List<Playlist>? Playlists;
    }
}
