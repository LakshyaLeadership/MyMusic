using System;
using System.Collections.Generic;

namespace MyMusic.ViewModels
{
    public class Album
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public float Price { get; set; }
        public float Rating { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Copyright { get; set; }
        public string ItunesReview { get; set; }
        public string AlbumLogo { get; set; }
        public string TagsCsv { get; set; }
        public bool IsMasteredForItunes { get; set; }

        public virtual ICollection<Song> Songs { get; set; }
        public long? ArtistId { get; set; }
        public virtual Artist Artist { get; set; }
    }
}