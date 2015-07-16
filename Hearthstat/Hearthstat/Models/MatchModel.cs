using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hearthstat.Models
{
    public class MatchModel
    {

        [JsonProperty("User")]
        public string User { get; set; }
        [JsonProperty("UserClass")]
        public string SserClass { get; set; }
        [JsonProperty("SubClass")]
        public string SubClass { get; set; }
        [JsonProperty("OpponentClass")]
        public string OpponentClass { get; set; }
        [JsonProperty("OpponentSubClass")]
        public string OpponentSubClass { get; set; }
        [JsonProperty("MatchResult")]
        public bool MatchResult { get; set; }
        [JsonProperty("PlayerRank")]
        public int PlayerRank { get; set; }
        [JsonProperty("Season")]
        public int Season { get; set; }
        [JsonProperty("Comment")]
        public string Comment { get; set; }
        [JsonProperty("UserId")]
        public string UserId { get; set; }

    }
}