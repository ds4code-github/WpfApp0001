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
using System.Windows.Threading;

namespace WpfApp0001
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly DispatcherTimer _animationsTimer = new DispatcherTimer();
        private bool gehtNachRechts = true;
        public MainWindow()
        {
            InitializeComponent();
            _animationsTimer.Interval = TimeSpan.FromMilliseconds(50);
            _animationsTimer.Tick += PositioniereBall;
        }

        private void PositioniereBall(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            var x = Canvas.GetLeft(Ball);
            if ((x+Ball.ActualWidth)>=Spielplatz.ActualWidth)
            {
                gehtNachRechts = false;
            } 
            else if ((x-0)<=Spielplatz.MinWidth)
            {
                gehtNachRechts = true;
            }
            if (gehtNachRechts)
            {
                Canvas.SetLeft(Ball, x + 5);
            }
            else
            {
                Canvas.SetLeft(Ball, x - 5);
            }
        }

        private void StartStopButton_Click(object sender, RoutedEventArgs e)
        {
            if (_animationsTimer.IsEnabled)
            {
                _animationsTimer.Stop();
            } 
            else
            {
                _animationsTimer.Start();
            }
            
            var mitteX = Spielplatz.ActualWidth / 2 - 15;
            var mitteY = Spielplatz.ActualHeight / 2 - 15;

            Canvas.SetLeft(Ball, mitteX);
            Canvas.SetTop(Ball, mitteY);
        }
    }
}
