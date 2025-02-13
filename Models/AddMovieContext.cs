using Microsoft.EntityFrameworkCore;

namespace Mission06_Adams.Models
{
    // DbContext class for interacting with the Movie database
    public class AddMovieContext : DbContext
    {
        // Constructor to initialize the DbContext with options
        public AddMovieContext(DbContextOptions<AddMovieContext> options) : base (options) 
        {
        }

        // DbSet property representing the Movies table in the database
        public DbSet<Movie> Movies { get; set; }
    }
}
