using System.Runtime.Serialization;

namespace Movies.DTO
{
    [DataContract]
    public class GenreDTO
    {
        [DataMember(Name = "id")]
        public int Id { get; set; }

        [DataMember(Name = "name")]
        public string Name { get; set; }
    }
}
