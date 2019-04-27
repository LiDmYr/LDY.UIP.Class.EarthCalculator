using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using LDY.Lesson8.EarthCalculator.BAL.EarthCalculator.Services;
using LDY.Lesson8.EarthCalculator.Core.DI;
using LDY.Lesson8.EarthCalculator.Shared.Interfaces;
using LDY.Lesson8.EarthCalculator.Shared.Models;
using LDY.Lesson8.EarthCalculator.UI.WPF.Controls;

namespace LDY.Lesson8.EarthCalculator.UI.WPF {
    /// <summary>
    /// Interaction logic for EarthCalculatorUI.xaml
    /// </summary>
    public partial class EarthCalculatorUI : UserControl, IEarthCalculatorUI {

        public IEarthCalculator EarthCalculator {
            get {
                if (_EarthCalculator == null) {
                    _EarthCalculator = AppContainer.Resolve<IEarthCalculator>();
                }
                return _EarthCalculator;
            }
        }
        private IEarthCalculator _EarthCalculator;

        public ILogger Logger {
            get {
                if (_Logger == null) {
                    _Logger = AppContainer.Resolve<ILogger>();
                }
                return _Logger;
            }
        }
        private ILogger _Logger;

        public EarthCalculatorUI() {
            InitializeComponent();
        }

        public List<Point> GetPoints() {
            var points = new List<Point>();
            foreach (var pointView in PointViewsContainer.Children) {
                var piv = pointView as PointInputView;
                if (piv != null) {
                    points.Add(piv.GetPoint());
                }
            }
            return points;
        }

        public void ShowEarthSquare(List<Point> points) {
            if (EarthCalculator == null) {
                MessageBox.Show("EarthCalculator == null");
                return;
            }
            EarthCalculationResult earthCalculationResult = EarthCalculator.GetEarthCalculationResult(points);
            if (earthCalculationResult.IsCalculationSuccess && earthCalculationResult.PointsValidationResult.IsPointsValid) {
                MessageBox.Show($"EarthSquare is {earthCalculationResult.EarthSquare}");
            } else {
                MessageBox.Show("Points are not valid");
            }
        }

        private void ShowSquare_Click(object sender, RoutedEventArgs e) {
            Logger.Fatal($"[{this.GetType().Name}]: ShowSquare_Click");

            ShowEarthSquare(GetPoints());
        }

        private void AddPointInput_Click(object sender, RoutedEventArgs e) {
            PointInputView newPoint = new PointInputView(0, 0);
            newPoint.DeletedPointView += OnDeletedPointView;
            PointViewsContainer.Children.Add(newPoint);
        }

        private void OnDeletedPointView(PointInputView viewToDelete) {
            viewToDelete.DeletedPointView -= OnDeletedPointView;
            PointViewsContainer.Children.Remove(viewToDelete);
        }
    }
}
