using System;
using System.Collections.Generic;

namespace MyMusic.EFCoreDbFirst
{
    public partial class Album
    {
        public Album()
        {
            Song = new HashSet<Song>();
        }

        public long Id { get; set; }
        public DateTime Created { get; set; }
        public DateTime? LastModified { get; set; }
        public string Title { get; set; }
        public float Price { get; set; }
        public float Rating { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Copyright { get; set; }
        public string ItunesReview { get; set; }
        public string AlbumLogo { get; set; }
        public string TagsCsv { get; set; }
        public bool IsMasteredForItunes { get; set; }
        public long? ArtistId { get; set; }

        public virtual Artist Artist { get; set; }
        public virtual ICollection<Song> Song { get; set; }
    }
}
