using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Movies.Application;
using Movies.Domain;
using Movies.Infrastructure;

namespace Movies
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            // Configure services
            var services = new ServiceCollection();
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    "Server=KRISTIYAN\\MSSQLSERVER03;Database=MoviesORM;Trusted_Connection=True;TrustServerCertificate=True",
                    sqlOptions => sqlOptions.EnableRetryOnFailure(
                        maxRetryCount: 5, // Number of retry attempts
                        maxRetryDelay: TimeSpan.FromSeconds(10), // Maximum delay between retries
                        errorNumbersToAdd: null // Optional: specify SQL error numbers to retry on
                    )
                )
            );
            services.AddScoped<ApplicationDbContext, ApplicationDbContext>();
            services.AddScoped<IMovieRepository, MovieRepository>();
            services.AddScoped<ICsvReaderService, CsvReaderService>();

            var serviceProvider = services.BuildServiceProvider();

            // Create a scope for resolving services
            using var scope = serviceProvider.CreateScope();
            var csvReaderService = scope.ServiceProvider.GetRequiredService<ICsvReaderService>();
            var movieRepository = scope.ServiceProvider.GetRequiredService<IMovieRepository>();

            // Read movies from CSV and save to the database
            //var movies = csvReaderService.ReadMoviesFromCsv("../../../RawData/imdb_top_2000_movies.csv");
            //var movies = await movieRepository.GetAllMoviesAsync();
            //foreach (var movie in movies)
            //{
            //    //await movieRepository.AddMovieAsync(movie);
            //    Console.WriteLine( $"{movie.MovieName} ({movie.ReleaseYear})");
            //}
            var singleMovie = await movieRepository.GetMovieByNameAsync("godfather");
            Console.WriteLine($"{singleMovie.MovieName}: {singleMovie.Director}");
        }
    }
}
