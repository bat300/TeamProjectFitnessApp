using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessDietApp.Data.DTO.Response
{
    public class Hits
    {
        [JsonProperty("q")]
        public string Query { get; set; }
        [JsonProperty("from")]
        public int From { get; set; }
        [JsonProperty("to")]
        public int To { get; set; }
        [JsonProperty("count")]
        public int NumberOfResults { get; set; }
        [JsonProperty("hits")]
        public Hit[] MatchingResults { get; set; }
    }
}
