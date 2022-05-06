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

namespace project1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int time = 0;
        private DispatcherTimer timer;
        public MainWindow()
        {
            InitializeComponent();
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += timerTick;
        }

        private void timerTick(object sender, EventArgs e)
        {
            time++;
            if (time < 0)
            {
                timeLabel.Content = "waiting to restart: " + (time * -1).ToString();
            }
            else
            {
                timeLabel.Content = TimeSpan.FromSeconds(time).ToString(@"mm\:ss");
            }

            if (time >= 60*20)
            {
                this.timeIsUp();
            }
        }

        private void startButton_Click(object sender, RoutedEventArgs e)
        {
            timer.Start();
        }
        private void stopButton_Click(object sender, RoutedEventArgs e)
        {
            timer.Stop();
        }

        private void timeIsUp()
        {
            System.Media.SystemSounds.Exclamation.Play();
            Window1 notificationWindow = new Window1();
            notificationWindow.Show();
            time = -60;
        }
        
    }
}
