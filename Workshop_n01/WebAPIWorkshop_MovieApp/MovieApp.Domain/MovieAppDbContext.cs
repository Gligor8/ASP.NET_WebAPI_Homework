using Microsoft.EntityFrameworkCore;
using System;
using WebAPIWorkshop_MovieApp.Models;

namespace MovieApp.Domain
{
    public class MovieAppDbContext : DbContext
    {
        public MovieAppDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Movie> Movies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Movie>()
                .Property(x => x.Id)
                .HasMaxLength(100);
            modelBuilder.Entity<Movie>()
                .Property(x => x.Title)
                .HasMaxLength(100);
            modelBuilder.Entity<Movie>()
                .Property(x => x.Description)
                .HasMaxLength(500);
            modelBuilder.Entity<Movie>()
                .Property(x => x.Year)
                .HasMaxLength(500);
            modelBuilder.Entity<Movie>()
                .Property(x => x.Genre);
                

        }
    }
}
