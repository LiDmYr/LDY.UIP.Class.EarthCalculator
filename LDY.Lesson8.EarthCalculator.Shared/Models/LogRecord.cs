using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LDY.Lesson8.EarthCalculator.Shared.Models {

    public class LogRecord {
        [JsonIgnore]
        public string NotSerializableField { get; set; }

        public DateTime CreatedAt { get; set; }

        public string Message { get; set; }

        public LogLevel LogLevel { get; set; }

        public override string ToString() {
            return $"\n\tMessage='{Message}';\n\tCreatedAt={CreatedAt};\n\tLogLevel={LogLevel};";
        }
    }

    public enum LogLevel {
        Debug = 10,
        Info = 20,
        Warn = 30,
        Error = 40,
        Fatal = 50
    }
}
