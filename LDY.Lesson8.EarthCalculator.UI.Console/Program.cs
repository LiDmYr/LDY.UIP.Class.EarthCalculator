using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LDY.Lesson8.EarthCalculator;
using LDY.Lesson8.EarthCalculator.BAL.EarthCalculator.Services;

namespace LDY.Lesson8.EarthCalculator.UI.Console {
    class Program {
        static void Main(string[] args) {
            var pointsValidator = new PointsValidator();
            var earthCalculator = new BAL.EarthCalculator.Services.EarthCalculator(pointsValidator);
            new EarthCalculatorUI(earthCalculator).StartCalculation();
        }
    }
}
