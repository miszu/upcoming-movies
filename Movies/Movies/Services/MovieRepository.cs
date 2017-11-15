using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Movies.DTO;
using Movies.Interfaces;
using Movies.Models;
using Newtonsoft.Json;

namespace Movies.Services
{
    public class MovieRepository : IMovieRepository
    {
        HttpClient _httpClient;
        IDictionary<int, string> _genreNames;

        private string ServerApiBase = "https://api.themoviedb.org/3";
        private string ServerApiKey = "1f54bd990f1cdfb230adb312546d765d";
        private string ImageBaseUrl = "https://image.tmdb.org/t/p/w780";

        public MovieRepository()
        {
            _httpClient = new HttpClient();
        }

        public async Task<IEnumerable<Movie>> GetMovies(int page)
        {
            if (_genreNames == null)
            {
                _genreNames = await GetGenreDictionary();
            }

            var url = $"{ServerApiBase}/movie/upcoming?page={page}&language=en-US&api_key={ServerApiKey}";
            var response = await _httpClient.GetStringAsync(url);
            var upcomingMoviesDTOs = JsonConvert.DeserializeObject<MoviesDTO>(response).Results;
            var upcomingMovies = upcomingMoviesDTOs.Select(dto => GetMovieFromDto(dto));

            return upcomingMovies;
        }

        public async Task<IEnumerable<Movie>> FindMovies(string query)
        {
            if (_genreNames == null)
            {
                _genreNames = await GetGenreDictionary();
            }

            var url = $"{ServerApiBase}/search/movie?api_key={ServerApiKey}&language=en-US&query={Uri.EscapeUriString(query)}&page=1&include_adult=false";
            var response = await _httpClient.GetStringAsync(url);
            var moviesDTOs = JsonConvert.DeserializeObject<MoviesDTO>(response).Results;
            var movies = moviesDTOs.Select(dto => GetMovieFromDto(dto));

            return movies;
        }

        private async Task<IDictionary<int, string>> GetGenreDictionary()
        {
            var url = $"{ServerApiBase}/genre/movie/list?api_key={ServerApiKey}";
            var response = await _httpClient.GetStringAsync(url);
            var allGenresDTO = JsonConvert.DeserializeObject<AllGenresDTO>(response);

            return allGenresDTO.Genres.ToDictionary(x => x.Id, x => x.Name);
        }

        private Movie GetMovieFromDto(MovieDTO movieDTO)
        {
            var genresNames = movieDTO.GenreIds.Select(id => _genreNames.ContainsKey(id) ? _genreNames[id] : "").Where(g => string.IsNullOrEmpty(g) == false).ToArray();
            var posterUrl = $"{ImageBaseUrl}{movieDTO.PosterPath}";
            var backdropUrl = $"{ImageBaseUrl}{movieDTO.BackdropPath}";

            return new Movie(movieDTO.Title, movieDTO.Overview, posterUrl, backdropUrl, movieDTO.ReleaseDate, genresNames, (int) movieDTO.Popularity);
        }
    }
}
