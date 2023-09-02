using eTicket.Models;
using Microsoft.EntityFrameworkCore;

namespace eTicket.Data;

public class AppDbContext : DbContext
{
    internal readonly object Actors_Movies;

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ActorMovie>().HasKey(am => new
        {
            am.ActorId,
            am.MovieId
        });
        modelBuilder.Entity<ActorMovie>().HasOne(m=>m.Movie).WithMany(am =>am.ActorsMovies).HasForeignKey(am=>am.MovieId);
        modelBuilder.Entity<ActorMovie>().HasOne(m=>m.Actor).WithMany(am =>am.ActorsMovies).HasForeignKey(am=>am.ActorId);
        
        base.OnModelCreating(modelBuilder);
    }

    public DbSet<ActorMovie> ActorMovies { get; set; }
    public DbSet<Movie> Movies { get; set; }
    public DbSet<Actor> Actors { get; set; }
    public DbSet<Producer> Producers { get; set; }
    public DbSet<Cinema> Cinemas { get; set; }
}
