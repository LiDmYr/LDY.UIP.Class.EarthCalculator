using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LDY.Lesson8.EarthCalculator;
using LDY.Lesson8.EarthCalculator.BAL.EarthCalculator.Services;
using LDY.Lesson8.EarthCalculator.Core.DI;

namespace LDY.Lesson8.EarthCalculator.UI.Console {
    class Program {
        static void Main(string[] args) {
            AppContainer.ConfigureContainer();

            new EarthCalculatorUI().StartCalculation();
        }
    }
}
