using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary
{
    class StandartParamsRequestModel
    {
        [JsonProperty("current_page")]
        public int CurrentPage { get; set; }

        [JsonProperty("per_page")]
        public int PerPage { get; set; }

        [JsonProperty("last_page")]
        public int LastPage { get; set; }

        [JsonProperty("data")]
        public List<DateTime> Data { get; set; }

        [JsonProperty("total")]
        public int Total { get; set; }
    }
}
