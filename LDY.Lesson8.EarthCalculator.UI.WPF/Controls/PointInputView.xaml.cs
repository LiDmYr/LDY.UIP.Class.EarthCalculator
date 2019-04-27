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
        private bool IsInitializedComponent;

        private double _X;
        public double X {
            get { return _X; }
            set {
                _X = value;
                InputY.Text = _X.ToString();
            }
        }

        private double _Y;
        public double Y {
            get { return _Y; }
            set {
                _Y = value;
                InputX.Text = _Y.ToString();
            }
        }

        private double ParsedX;
        private double ParsedY;

        public delegate void PointViewStateHandler(PointInputView viewToDelete);
        public event PointViewStateHandler DeletedPointView;

        public PointInputView() {
            InitializeComponent();
            IsInitializedComponent = true;
        }

        public PointInputView(int x, int y) : this() {
            X = x;
            Y = y;
        }

        public bool IsPointValid {
            get {
                return ParsedX == -1 || ParsedY == -1;
            }
        } 

        public Point GetPoint() {
            return IsPointValid? new Point() : new Point(ParsedX, ParsedY);
        }

        private void TextChanged(object sender, TextChangedEventArgs e) {
            if (!IsInitializedComponent) {
                return;
            }
            bool valXres = Double.TryParse(InputX.Text, out ParsedX);
            bool valYres = Double.TryParse(InputY.Text, out ParsedY);
            if (!valXres || !valYres || ParsedX < 0 || ParsedY < 0) {
                ValidationBlock.Visibility = Visibility.Visible;
                ValidationBlock.Text = "X OR Y value is not valid";
                ParsedX = -1;
                ParsedY = -1;
            } else {
                ValidationBlock.Visibility = Visibility.Collapsed;
                ValidationBlock.Text = "";
            }
        }

        private void DeletePointViewButton_Click(object sender, RoutedEventArgs e) {
            if (DeletedPointView == null) { return; }
            DeletedPointView(this);
        }
    }
}
