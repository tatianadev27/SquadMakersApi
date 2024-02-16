using Domain.Aggregate;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Persintence.Database
{
    public class JokeDbContext : DbContext
    {
        public JokeDbContext(DbContextOptions<JokeDbContext> options)
            : base(options)
        {
        }
        public DbSet<Joke> Jokes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Joke>(build =>
            {
                build.HasKey(entry => entry.Id);
                build.Property(entry => entry.Id)
                .HasConversion(entry => entry.Value, value => new JokeId(value))
                .ValueGeneratedOnAdd();

                build.Property(entry => entry.Text)
                .HasConversion(entry => entry.Value, value => new JokeText(value));
            });
        }
    }
}
