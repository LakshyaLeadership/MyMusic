using System;
using System.Collections.Generic;

namespace MyMusic.EFCoreDbFirst
{
    public partial class Song
    {
        public long Id { get; set; }
        public DateTime Created { get; set; }
        public DateTime? LastModified { get; set; }
        public long? AlbumId { get; set; }
        public string Name { get; set; }
        public TimeSpan Time { get; set; }
        public float PopularityPerc { get; set; }
        public float Price { get; set; }
        public long? ArtistId { get; set; }

        public virtual Album Album { get; set; }
        public virtual Artist Artist { get; set; }
    }
}
