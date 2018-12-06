using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace LDY.Lesson8.EarthCalculator.Shared.Interfaces {
    public interface IEarthCalculatorUI {
        List<Point> GetPoints();

        void ShowEarthSquare(List<Point> points);
    }
}
