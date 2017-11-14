using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Movies.DTO
{
    [DataContract]
    public class UpcomingMoviesDTO
    {
        [DataMember(Name = "results")]
        public IList<MovieDTO> Results { get; set; }

        [DataMember(Name = "total_pages")]
        public int TotalPages { get; set; }
    }
}
