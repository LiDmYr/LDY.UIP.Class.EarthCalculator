using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LDY.Lesson8.EarthCalculator.Shared.Models {
    public class EarthCalculationResult {
        public double EarthSquare { get; set; }

        public bool IsCalculationSuccess { get; set; }

        public PointsValidationResult PointsValidationResult { get; set; }
    }
}
