using System;

namespace MyMusic.EFCoreCodeFirst
{
    public class Song : Entity
    {
        public long? AlbumId { get; set; }

        public string Name { get; set; }
        public TimeSpan Time { get; set; }
        public float PopularityPerc { get; set; }
        public float Price { get; set; }
        public long? ArtistId { get; set; }
        public virtual Artist Artist { get; set; }

    }
}