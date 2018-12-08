using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LDY.Lesson8.EarthCalculator.Shared.Models {
    public class LogRecord {

        [JsonProperty("L")]
        public LogLevel logLevel { get; set; }

        [JsonProperty("C")]
        public DateTime CreatedAt { get; set; }

        [JsonProperty("M")]
        public string Message { get; set; }

        [JsonIgnore]
        public string Password { get; set; } = "PAsswordasdasda";
    }
}
