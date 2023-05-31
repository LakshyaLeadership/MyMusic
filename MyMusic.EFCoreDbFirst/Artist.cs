using System;
using System.Collections.Generic;

namespace MyMusic.EFCoreDbFirst
{
    public partial class Artist
    {
        public Artist()
        {
            Album = new HashSet<Album>();
            Song = new HashSet<Song>();
        }

        public long Id { get; set; }
        public DateTime Created { get; set; }
        public DateTime? LastModified { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Album> Album { get; set; }
        public virtual ICollection<Song> Song { get; set; }
    }
}
