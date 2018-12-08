using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using LDY.Lesson8.EarthCalculator.Core;
using LDY.Lesson8.EarthCalculator.Shared.Interfaces;
using LDY.Lesson8.EarthCalculator.Shared.Models;

namespace LDY.Lesson8.EarthCalculator.UI.Console {
    public class EarthCalculatorUI : IEarthCalculatorUI {

        public IEarthCalculator EarthCalculator { get; set; }

        public EarthCalculatorUI() {
            EarthCalculator = AppContainer.Resolve<IEarthCalculator>();
        }

        internal void StartCalculation() {
            string mainString = string.Empty;
            while (mainString != "quit") {
                System.Console.WriteLine("Please input points");
                List<Point> points = GetPoints();
                ShowEarthSquare(points);
                System.Console.WriteLine("Please write 'quit' to quit or something else to repeat calculation");
                mainString = System.Console.ReadLine();
            }
        }

        public List<Point> GetPoints() {
            // TODO: GET POINTS FROM CONSOLE;
            return new List<Point>() {
                new Point(0, 0),
                new Point(0, 500),
                new Point(500, 500),
                new Point(500, 0)
            };
        }

        public void ShowEarthSquare(List<Point> points) {
            EarthCalculationResult earthCalculationResult = EarthCalculator.GetEarthCalculationResult(points);
            if (earthCalculationResult.IsCalculationSuccess && earthCalculationResult.PointsValidationResult.IsPointsValid) {
                System.Console.WriteLine($"EarthSquare is {earthCalculationResult.EarthSquare}");
            } else {
                System.Console.WriteLine("Points are not valid");
            }
        }
    }
}
