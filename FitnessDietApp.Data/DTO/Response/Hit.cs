using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessDietApp.Data.DTO.Response
{
    class Hit
    {
        [JsonProperty("recipe")]
        public Recipe Recipe { get; set; }
    }
}
