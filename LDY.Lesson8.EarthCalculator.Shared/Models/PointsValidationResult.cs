using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LDY.Lesson8.EarthCalculator.Shared.Models {
    public class PointsValidationResult {
        public bool IsPointsValid { get; set; }

        public List<PointsMistakes> PointsMistakes { get; set; }
    }
}
