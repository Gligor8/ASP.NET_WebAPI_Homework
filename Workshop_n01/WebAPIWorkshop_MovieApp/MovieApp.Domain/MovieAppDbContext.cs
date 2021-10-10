using Microsoft.EntityFrameworkCore;
using MovieApp.Domain.Models;
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
        public DbSet<User> Users { get; set; }

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
            modelBuilder.Entity<Movie>()
                .HasOne(x => x.User)
                .WithMany(x => x.Movies)
                .HasForeignKey(x => x.UserId);
            
                

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>()
                .Property(x => x.Id)
                .HasMaxLength(100);
            modelBuilder.Entity<User>()
                .Property(x => x.Username)
                .HasMaxLength(100);
            modelBuilder.Entity<User>()
                .Property(x => x.FirstName)
                .HasMaxLength(500);
            modelBuilder.Entity<User>()
                .Property(x => x.LastName)
                .HasMaxLength(500);
            modelBuilder.Entity<User>()
                .Property(x => x.FavoriteGenre);
            //modelBuilder.Entity<User>()
            //    .Property(x => x.Movies);
                //.HasForeignKey(x => x.Id);





        }
    }
}
