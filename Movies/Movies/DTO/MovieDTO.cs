using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Movies.DTO
{
    [DataContract]
    public class MovieDTO
    {
        [DataMember(Name = "id")]
        public int Id { get; set; }

        [DataMember(Name = "title")]
        public string Title { get; set; }

        [DataMember(Name = "popularity")]
        public double Popularity { get; set; }

        [DataMember(Name = "poster_path")]
        public string PosterPath { get; set; }

        [DataMember(Name = "genre_ids")]
        public IList<int> GenreIds { get; set; }

        [DataMember(Name = "backdrop_path")]
        public string BackdropPath { get; set; }

        [DataMember(Name = "overview")]
        public string Overview { get; set; }

        [DataMember(Name = "release_date")]
        public string ReleaseDate { get; set; }
    }
}
