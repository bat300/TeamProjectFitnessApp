using FitnessDietApp.Data.DTO.Request;
using FitnessDietApp.Data.DTO.Response;
using Newtonsoft.Json;

namespace FitnessDietApp.Data.DTO
{
    public class SearchInfo
    {
        [JsonProperty("from")]
        public int From { get; set; }
        [JsonProperty("to")]
        public int To { get; set; }
        [JsonProperty("dietLabels")]
        public Diet Diet { get; set; }
        [JsonProperty("healthLabels")]
        public Health Health { get; set; }
        [JsonProperty("returns")]
        public Hits QueryParametrsAndResults { get; set; }
    }
}
