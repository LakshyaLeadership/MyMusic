using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace MyMusic.EFCoreCodeFirst
{
    public class MyMusicContext : DbContext
    {
        private readonly IConfiguration _configuration;
        public DbSet<Album> Album { get; set; }
        public DbSet<Song> Song { get; set; }

        public MyMusicContext(DbContextOptions<MyMusicContext> options, IConfiguration configuration)
            : base(options)
        {
            _configuration = configuration;
        }

        protected override void OnModelCreating(ModelBuilder mb)
        {
            base.OnModelCreating(mb);
            mb.Entity<Album>().HasMany(a => a.Songs).WithOne().HasForeignKey(a => a.AlbumId);
            mb.Entity<Album>().HasOne(a => a.Artist).WithMany().HasForeignKey(a => a.ArtistId);
            mb.Entity<Song>().HasOne(s => s.Artist).WithMany().HasForeignKey(a => a.ArtistId);
        }
    }
}