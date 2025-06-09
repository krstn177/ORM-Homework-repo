using Movies.Domain;
using Microsoft.EntityFrameworkCore;

namespace Movies.Infrastructure
{
    public class MovieRepository : IMovieRepository
    {
        private readonly ApplicationDbContext _context;

        public MovieRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddMovieAsync(Movie movie)
        {
            _context.Movies.Add(movie);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Movie>> GetAllMoviesAsync()
        {
            return await _context.Movies.ToListAsync();
        }

        public async Task<Movie> GetMovieByNameAsync(string name)
        {
            return await _context.Movies.FirstOrDefaultAsync(movie => movie.MovieName.ToLower().Contains(name.ToLower()));
        }

        public async Task<IEnumerable<Movie>> GetMoviesByNameMatchAsync(string nameMatch)
        {
            return await _context.Movies
                .Where(movie => movie.MovieName != null && movie.MovieName.ToLower().Contains(nameMatch.ToLower()))
                .ToListAsync();
        }
    }
}