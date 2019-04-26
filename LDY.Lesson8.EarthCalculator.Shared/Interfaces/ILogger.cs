using LDY.Lesson8.EarthCalculator.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LDY.Lesson8.EarthCalculator.Shared.Interfaces {
    public interface ILogger {
        LogLevel CurrentLogLevel { get; set; }
        void Debug(string message);
        void Info(string message);
        void Warn(string message);
        void Error(string message);
        void Fatal(string message);
    }
}
