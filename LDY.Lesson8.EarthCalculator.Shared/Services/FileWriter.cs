using LDY.Lesson8.EarthCalculator.Shared.Interfaces;
using LDY.Lesson8.EarthCalculator.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LDY.Lesson8.EarthCalculator.Shared.Services {
    public class FileWriter : IFileWriter {
        public void Write(LogRecord logRecord) {
            Console.WriteLine("FileRepository =>" + logRecord);
        }
    }
}
