using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using LDY.Lesson8.EarthCalculator.Shared.Interfaces;
using LDY.Lesson8.EarthCalculator.Shared.Models;

namespace LDY.Lesson8.EarthCalculator.Shared.Services {
    public class FileWriter : IFileWriter
    {
        public IJONSerializer JsonSerializer { get; set; }
        string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "LogStorage.json");
        public FileWriter(IJONSerializer jsonSerializer)
        {
            this.JsonSerializer = jsonSerializer;
        }
        public void Write(LogRecord logRecord)
        {
            string TextFromFile = LoadAndReadFile();
            List<LogRecord> Records = this.JsonSerializer.Deserialize<List<LogRecord>>(TextFromFile);
            if (Records==null) {
                Records = new List<LogRecord>();
            }
            Records.Add(logRecord);
            string SerializedObjects = this.JsonSerializer.Serialize<List<LogRecord>>(Records);
            SaveToFile(SerializedObjects);
        }
        private string LoadAndReadFile()
        {
            if (!File.Exists(this.path)) {
                File.Create(this.path).Dispose();
            }
            string result = null;
            if (File.Exists(this.path)) {
                result = File.ReadAllText(this.path, Encoding.UTF8);
            } else {
                // TODO: Notify
            }
            return result;
        }

        private void SaveToFile(string text)
        {
            if (!File.Exists(this.path)) {
                File.Create(this.path).Dispose();
            }
            File.WriteAllText(this.path, text);
        }
    }
}
