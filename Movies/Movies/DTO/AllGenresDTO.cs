using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Movies.DTO
{
    [DataContract]
    public class AllGenresDTO
    {
        [DataMember(Name = "genres")]
        public IList<GenreDTO> Genres { get; set; }
    }
}