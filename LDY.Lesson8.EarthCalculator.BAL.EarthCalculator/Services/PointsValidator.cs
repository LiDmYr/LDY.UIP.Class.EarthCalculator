using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using LDY.Lesson8.EarthCalculator.Shared.Interfaces;
using LDY.Lesson8.EarthCalculator.Shared.Models;

namespace LDY.Lesson8.EarthCalculator.BAL.EarthCalculator.Services {
    public class PointsValidator : IPointsValidator {
        private ILogger Logger;

        public PointsValidator(ILogger logger) {
            Logger = logger;
        }

        public PointsValidationResult GetPointsValidationResult(IEnumerable<Point> points) {
            foreach (var point in points) {
                // TODO Check is points and points combinations are correct
            }

            bool IsPointsValid = true;
            if (IsPointsValid) {
                Logger.Info($"[{this.GetType().Name}]: Points are Valid");
            } else {
                Logger.Warn($"[{this.GetType().Name}]: Points are not Valid");
            }       

            return new PointsValidationResult() { IsPointsValid = IsPointsValid };
        }
    }
}
