using System;
using System.Collections.Generic;

namespace Movies.Models
{
    public class Movie
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public string PosterUrl { get; private set; }
        public string BackdropUrl { get; private set; }
        public DateTime? ReleaseDate { get; private set; }
        public ICollection<string> Genres { get; private set; }
        public int Popularity { get; private set; }

        public Movie(string name, string description, string posterUrl, string backdropUrl, string releaseDate, ICollection<string> genres, int popularity)
        {
            Name = name;
            Description = description;
            PosterUrl = posterUrl;
            BackdropUrl = backdropUrl;
            Genres = genres;
            Popularity = popularity;

            DateTime _releaseDate;
            if (DateTime.TryParse(releaseDate, out _releaseDate))
            {
                ReleaseDate = _releaseDate;
            }
        }
    }
}
