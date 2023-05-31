using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace MyMusic.EFCoreDbFirst
{
    public partial class MyMusicDbFirstContext : DbContext
    {
        public MyMusicDbFirstContext()
        {
        }

        public MyMusicDbFirstContext(DbContextOptions<MyMusicDbFirstContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Album> Album { get; set; }
        public virtual DbSet<Artist> Artist { get; set; }
        public virtual DbSet<Song> Song { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=localhost;Initial Catalog=MyMusic;User ID=sa;Password=C0ffee@nyWhere!;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<Album>(entity =>
            {
                entity.HasIndex(e => e.ArtistId);

                entity.HasOne(d => d.Artist)
                    .WithMany(p => p.Album)
                    .HasForeignKey(d => d.ArtistId);
            });

            modelBuilder.Entity<Song>(entity =>
            {
                entity.HasIndex(e => e.AlbumId);

                entity.HasIndex(e => e.ArtistId);

                entity.HasOne(d => d.Album)
                    .WithMany(p => p.Song)
                    .HasForeignKey(d => d.AlbumId);

                entity.HasOne(d => d.Artist)
                    .WithMany(p => p.Song)
                    .HasForeignKey(d => d.ArtistId);
            });
        }
    }
}
