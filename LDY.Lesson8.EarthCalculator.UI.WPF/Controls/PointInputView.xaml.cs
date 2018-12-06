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

namespace LDY.Lesson8.EarthCalculator.UI.WPF.Controls {
    /// <summary>
    /// Interaction logic for PointInputView.xaml
    /// </summary>
    public partial class PointInputView : UserControl {
        private double _X;
        public double X {
            get { return _X; }
            set {
                _X = value;
                PointX.Text = _X.ToString();
            }
        }

        private double _Y;
        public double Y {
            get { return _Y; }
            set {
                _Y = value;
                PointY.Text = _Y.ToString();
            }
        }

        public PointInputView() {
            InitializeComponent();
        }

        public Point GetPoint() {
            bool isXValid = Double.TryParse(PointX.Text, out double x);
            bool isYValid = Double.TryParse(PointY.Text, out double y);
            var result = isXValid && isYValid ? new Point(x, y) : new Point();
            return result;
        }
    }
}
