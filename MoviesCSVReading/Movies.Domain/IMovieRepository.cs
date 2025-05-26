using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movies.Domain
{
    public interface IMovieRepository
    {
        Task AddMovieAsync(Movie movie);
        Task<IEnumerable<Movie>> GetAllMoviesAsync();
    }
}