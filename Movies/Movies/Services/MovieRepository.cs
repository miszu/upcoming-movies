using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Movies.Interfaces;
using Movies.Models;

namespace Movies.Services
{
    public class MovieRepository : IMovieRepository
    {
        public Task<IEnumerable<Movie>> GetMovies(int count, int startingFromMovieIndex = 0)
        {
            //TODO download from the backend
            var titles = new[] { "Pulp Fiction", "Inspector Gadget", "Downsizing" };
            var movies = titles.Select(t => new Movie { Name = t, ReleaseDate = System.DateTime.Now, Genres = new [] { "Horror", "Action"},  PosterUrl = "https://images-na.ssl-images-amazon.com/images/M/MV5BMDdiYTUxOTMtZDA5Ni00ZTg0LWJiZTktZThjNTgyNzA0YzcwXkEyXkFqcGdeQXVyMjk3NTUyOTc@._CR233,7,713,713_UX402_UY402._SY201_SX201_AL_.jpg" });
                               
            return Task.FromResult(movies);
        }
    }
}
