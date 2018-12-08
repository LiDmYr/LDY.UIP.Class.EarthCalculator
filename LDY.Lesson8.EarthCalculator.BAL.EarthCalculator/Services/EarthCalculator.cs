﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using LDY.Lesson8.EarthCalculator.Shared.Interfaces;
using LDY.Lesson8.EarthCalculator.Shared.Models;

namespace LDY.Lesson8.EarthCalculator.BAL.EarthCalculator.Services {
    public class EarthCalculator : IEarthCalculator {
        public ILogger Logger { get; set; }
        public IPointsValidator PointsValidator { get; set; }

        public EarthCalculator(IPointsValidator pointsValidator, ILogger logger) {    
             PointsValidator = pointsValidator;
            this.Logger = logger;
        }

        public EarthCalculationResult GetEarthCalculationResult(IList<Point> points) {
            this.Logger.Info("Start");
            var earthCalculationResult = new EarthCalculationResult();
            earthCalculationResult.PointsValidationResult = PointsValidator.GetPointsValidationResult(points);
            bool isPointsValid = earthCalculationResult.PointsValidationResult.IsPointsValid;

            if (isPointsValid) {
                double result = CalculateEarthSquare(points);
                double alternativeResult = CalculateEarthSquare(points, true);
                earthCalculationResult.IsCalculationSuccess = result == alternativeResult;
                earthCalculationResult.EarthSquare = earthCalculationResult.IsCalculationSuccess? result : -1;
            } else {
                earthCalculationResult.EarthSquare = -1;
                earthCalculationResult.IsCalculationSuccess = isPointsValid;
            }
            Logger.Warning(earthCalculationResult.EarthSquare.ToString());
            return earthCalculationResult;
        }

        private double CalculateEarthSquare(IList<Point> points, bool isAlternativeCalculation = false) {
            double landArea = 0;
   
            for (int i = 0; i < points.Count; i++)
            {
                int nextIndex = (i == points.Count - 1) ? 0 : i + 1;
                int prevIndex = (i == 0) ? points.Count - 1 : i - 1;

                double par1 = isAlternativeCalculation ? points[i].X : points[i].Y;
                double par2_1 = isAlternativeCalculation ? points[nextIndex].Y : points[prevIndex].X;
                double par2_2 = isAlternativeCalculation ? points[prevIndex].Y : points[nextIndex].X;

                double tempLandArea = landArea;
                landArea += par1 * (par2_1 - par2_2);
            }
            double result = (double)Math.Abs(landArea / 2);
            return result;
        }
    }
}
