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
            return new List<Point> {
                PointView1.GetPoint(),
                PointView2.GetPoint(),
                PointView3.GetPoint(),
                PointView4.GetPoint()
            };
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
            Logger.Fatal("ShowSquare_Click");

            ShowEarthSquare(GetPoints());
        }
    }
}
