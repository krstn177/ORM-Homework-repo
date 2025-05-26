using Movies.Domain;
using System.Globalization;
using System.Data;
using ExcelDataReader;

namespace Movies.Application
{
    public class CsvReaderService : ICsvReaderService
    {
        public IEnumerable<Movie> ReadMoviesFromCsv(string filePath)
        {
            var movies = new List<Movie>();
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);

            using (var stream = File.Open(filePath, FileMode.Open, FileAccess.Read))
            using (var reader = ExcelReaderFactory.CreateCsvReader(stream))
            {
                var result = reader.AsDataSet();
                var table = result.Tables[0];
                bool isHeader = true;

                foreach (DataRow row in table.Rows)
                {
                    if (isHeader)
                    {
                        isHeader = false;
                        continue;
                    }

                    try
                    {
                        var movie = new Movie
                        {
                            MovieName = string.IsNullOrWhiteSpace(row[0]?.ToString()) ? null : row[0]?.ToString(),
                            ReleaseYear = int.TryParse(row[1]?.ToString(), out var year) ? year : null,
                            Duration = int.TryParse(row[2]?.ToString(), out var duration) ? duration : null,
                            ImdbRating = double.TryParse(row[3]?.ToString(), NumberStyles.Any, CultureInfo.InvariantCulture, out var rating) ? rating : null,
                            Metascore = double.TryParse(row[4]?.ToString(), NumberStyles.Any, CultureInfo.InvariantCulture, out var meta) ? meta : null,
                            Votes = int.TryParse(row[5]?.ToString(), NumberStyles.Any, CultureInfo.InvariantCulture, out var votes) ? votes : null,
                            Genre = row[6]?.ToString(),
                            Director = row[7]?.ToString(),
                            Cast = row[8]?.ToString(),
                            Gross = row[9]?.ToString()
                        };

                        // Skip invalid records (e.g., missing MovieName)
                        if (string.IsNullOrWhiteSpace(movie.MovieName))
                        {
                            throw new Exception("MovieName is required.");
                        }

                        movies.Add(movie);
                    }
                    catch (Exception ex)
                    {
                        // Log the error and skip the invalid record
                        Console.WriteLine($"Error processing row: {ex.Message}");
                    }
                }
            }

            return movies;
        }
    }
}
