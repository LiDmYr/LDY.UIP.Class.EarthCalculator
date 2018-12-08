using LDY.Lesson8.EarthCalculator.Shared.Interfaces;
using LDY.Lesson8.EarthCalculator.Shared.Models;
using System;

namespace LDY.Lesson8.EarthCalculator.BAL.EarthCalculator.Services {
    public class Logger : ILogger
    {
        public Logger(IConsoleWriter consoleWriter, IFileWriter fileWriter)
        {
            this.ConsoleWriter = consoleWriter;
            this.FileWriter = fileWriter;
        }
        public LogLevel CurrentLogLevel { get; set; } = LogLevel.Error;
        private IConsoleWriter ConsoleWriter { get; set; }
        private IFileWriter FileWriter { get; set; }

        public void Info(string message)
        {
            LogRecord logRecord = this.GetRecord(message, LogLevel.Info);
            if (LogLevel.Info >= this.CurrentLogLevel)
            {
                this.ConsoleWriter.Write(logRecord);
                this.FileWriter.Write(logRecord);
            }
        }

        public void Warning(string message)
        {
            LogRecord logRecord = this.GetRecord(message, LogLevel.Warning);
            if (LogLevel.Warning >= this.CurrentLogLevel)
            {
                this.ConsoleWriter.Write(logRecord);
                this.FileWriter.Write(logRecord);
            }
        }

        private LogRecord GetRecord(string message, LogLevel logLevel)
        {
            LogRecord logRecord = new LogRecord();
            logRecord.logLevel = logLevel;
            logRecord.Message = message;
            logRecord.CreatedAt = DateTime.Now;
            return logRecord;
        }

        public void Debug(string message)
        {
            
        }

        public void Error(string message)
        {
            
        }

        public void Fatal(string message)
        {
            
        }

 
    }
}
