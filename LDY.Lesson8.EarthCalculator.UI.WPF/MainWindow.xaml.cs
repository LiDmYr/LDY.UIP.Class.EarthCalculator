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

namespace LDY.Lesson8.EarthCalculator.UI.WPF {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();

            var pointsValidator = new PointsValidator();
            EarthCalculatorUIView.EarthCalculator = new BAL.EarthCalculator.Services.EarthCalculator(pointsValidator);
        }
    }
}
