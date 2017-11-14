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
            var backdropUrl = "https://image.tmdb.org/t/p/w780/mVr0UiqyltcfqxbAUcLl9zWL8ah.jpg";
            var posterUrl = "https://image.tmdb.org/t/p/w780/aMpyrCizvSdc0UIMblJ1srVgAEF.jpg";
            var description = "Thirty years after the events of the first film, a new blade runner, LAPD Officer K, unearths a long-buried secret that has the potential to plunge what's left of society into chaos. K's discovery leads him on a quest to find Rick Deckard, a former LAPD blade runner who has been missing for 30 years.";
            var movies = titles.Select(t => new Movie { Name = t, Description = description + description + description + description + description, ReleaseDate = System.DateTime.Now, Genres = new [] { "Horror", "Action"},  PosterUrl = posterUrl, BackdropUrl = backdropUrl, Popularity = 7.5 });
                               
            return Task.FromResult(movies);
        }
    }
}
