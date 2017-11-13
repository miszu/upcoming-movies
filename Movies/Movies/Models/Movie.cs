using System;
using System.Collections.Generic;

namespace Movies.Models
{
    public class Movie
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string PosterUrl { get; set; }
        public string BackdropUrl { get; set; }
        public DateTime ReleaseDate { get; set; }
        public ICollection<string> Genres { get; set; }
    }
}
