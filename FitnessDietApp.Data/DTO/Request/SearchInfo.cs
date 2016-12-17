﻿using FitnessDietApp.Data.DTO.Request;
using FitnessDietApp.Data.DTO.Response;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessDietApp.Data.DTO
{
    class SearchInfo
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
