using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LDY.Lesson8.EarthCalculator.Shared.Interfaces;
using LDY.Lesson8.EarthCalculator.Shared.Models;

namespace LDY.Lesson8.EarthCalculator.BAL.EarthCalculator.Services {
    public class Logger : ILogger {
        private IFileWriter FileRepository;
        private IDBRepository DbRepository;
        private IConsoleWriter ConsoleWriter;

        public Logger(IFileWriter fileRepository, IDBRepository dbRepository, IConsoleWriter consoleWriter) {
            FileRepository = fileRepository;
            DbRepository = dbRepository;
            ConsoleWriter = consoleWriter;
        }

        public LogLevel CurrentLogLevel { get; set; } = LogLevel.Debug;
        //public LogLevel CurrentLogLevel { get; set; } = LogLevel.Fatal;

        public void Debug(string message) {
            if (LogLevel.Debug >= CurrentLogLevel) {
                WriteToAll(message, LogLevel.Debug);
            }
        }

        public void Info(string message) {
            if (LogLevel.Info >= CurrentLogLevel) {
                WriteToAll(message, LogLevel.Info);
            }
        }

        public void Warn(string message) {
            if (LogLevel.Warn >= CurrentLogLevel) {
                WriteToAll(message, LogLevel.Warn);
            }
        }

        public void Error(string message) {
            if (LogLevel.Error >= CurrentLogLevel) {
                WriteToAll(message, LogLevel.Error);
            }
        }

        public void Fatal(string message) {
            if (LogLevel.Fatal >= CurrentLogLevel) {
                WriteToAll(message, LogLevel.Fatal);
            }
        }

        private void WriteToAll(string message, LogLevel logLevel) {
            var logRecord = new LogRecord() {
                CreatedAt = DateTime.Now,
                LogLevel = logLevel,
                Message = message,
                NotSerializableField = "NotSerializableField" + DateTime.Now.ToString()
            };

            FileRepository.Write(logRecord);
            DbRepository.Write(logRecord);
            ConsoleWriter.Write(logRecord);
        }
    }
}
