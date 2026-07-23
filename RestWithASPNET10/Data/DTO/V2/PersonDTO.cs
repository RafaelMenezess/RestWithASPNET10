using RestWithASPNET10.JsonSerializers;
using System.Text.Json.Serialization;

namespace RestWithASPNET10.Data.DTO.V2
{
    public class PersonDTO
    {
        //[JsonPropertyName("code")]
        public long Id { get; set; }
        //[JsonPropertyName("first_name")]
        public string FirstName { get; set; }
        //[JsonPropertyName("last_name")]
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Gender { get; set; }
        //[JsonPropertyName("birth_day")]
        [JsonConverter(typeof(DaterSerializer))]
        public DateTime? BirthDay { get; set; }
    }
}

