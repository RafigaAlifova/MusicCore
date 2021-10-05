using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Concrete.EntityFramework
{
    public class MusicLibraryContext : DbContext
    {
        public DbSet<Music> Musics { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Singer> Singers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlServer(@"server = (localdb)\MSSQLLocalDB; DataBase = MusicDb;Trusted_connection = true");
        }

        public DbSet<Music> Musics { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Singer> Singers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new MusicMap());
            modelBuilder.ApplyConfiguration(new GenreMap());
            modelBuilder.ApplyConfiguration(new SingerMap());

        }

        class GenreMap: IEntityTypeConfiguration<Genre>
        {
            public void Configure(EntityTypeBuilder<Genre> builder)
            {
                builder.ToTable("Genres");
                builder.HasKey(g => g.GenreId);

                builder.Property(e => e.GenreName).HasColumnName("Name");
                builder.Property(e => e.GenreId).HasColumnName("Id");

            }
        }

        class MusicMap : IEntityTypeConfiguration<Music>
        {
            public void Configure(EntityTypeBuilder<Music> builder)
            {
                builder.ToTable("Musics");
                builder.HasKey(s => s.MusicId);

                builder.Property(e => e.MusicName).HasColumnName("MusicName");
                builder.Property(e => e.MusicId).HasColumnName("Id");
                builder.Property(e => e.GenreId).HasColumnName("GenreId");
                builder.Property(e => e.SingerId).HasColumnName("SingerId");
            }
        }

        class SingerMap : IEntityTypeConfiguration<Singer>
        {
            public void Configure(EntityTypeBuilder<Singer> builder)
            {
                builder.ToTable("Singers");
                builder.HasKey(g => g.SingerId);

                builder.Property(e => e.SingerName).HasColumnName("Name");
                builder.Property(e => e.SingerId).HasColumnName("Id");

            }
        }
    }
}
