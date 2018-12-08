using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LDY.Lesson8.EarthCalculator.Shared.Models {
    public class LogRecord {
        public LogLevel logLevel { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Message { get; set; }
    }
}
