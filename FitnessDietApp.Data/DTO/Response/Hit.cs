using Newtonsoft.Json;

namespace FitnessDietApp.Data.DTO.Response
{
    public class Hit
    {
        [JsonProperty("recipe")]
        public Recipe Recipe { get; set; }
    }
}
