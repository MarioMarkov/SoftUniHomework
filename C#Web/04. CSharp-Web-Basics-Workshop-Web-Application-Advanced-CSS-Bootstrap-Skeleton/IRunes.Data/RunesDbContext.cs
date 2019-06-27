namespace IRunes.Data
{
    using IRunes.Models;
    using Microsoft.EntityFrameworkCore;

    public class RunesDbContext : DbContext
    {
        public RunesDbContext()
        {

        }
        public DbSet<User> Users{ get; set; }

        public DbSet<Album> Albums { get; set; }

        public DbSet<Track> Tracks { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder.UseSqlServer(DatabaseConfiguration.ConnectionString));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasKey(u => u.Id);

            modelBuilder.Entity<Track>()
                .HasKey(t => t.Id);

            modelBuilder.Entity<Album>()
                .HasKey(a => a.Id);

            modelBuilder.Entity<Album>()
                .HasMany(a => a.Tracks);
                
        }
    }
}
