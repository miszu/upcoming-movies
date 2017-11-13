using System.Collections.Generic;
using System.Threading.Tasks;
using Movies.Models;

namespace Movies.Interfaces
{
    public interface IMovieRepository
    {
        Task<IEnumerable<Movie>> GetMovies(int count, int startingFromMovieIndex = 0); 
    }
}
