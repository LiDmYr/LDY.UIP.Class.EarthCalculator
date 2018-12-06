using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using LDY.Lesson8.EarthCalculator.Shared.Models;

namespace LDY.Lesson8.EarthCalculator.Shared.Interfaces {
    public interface IPointsValidator {
        PointsValidationResult GetPointsValidationResult(IEnumerable<Point> points);
    }
}
