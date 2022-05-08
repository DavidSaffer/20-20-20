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
using System.Diagnostics;

namespace project1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// Ideas
    /// Add setting for timer to count up, or down 
    public partial class MainWindow : Window
    {
        private int time = 0;
        private DispatcherTimer timer;
        private int timerLength;
        private int waitLength;
        public MainWindow()
        {
            InitializeComponent();
            Properties.Settings.Default.Reload();
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += timerTick;
        }

        private void timerTick(object sender, EventArgs e)
        {
            timerLength = Properties.Settings.Default.timerLength;
            waitLength = Properties.Settings.Default.waitLength;

            time++;
            if (time < 0)
            {
                timeLabel.Content = "waiting to restart: " + TimeSpan.FromSeconds(time * -1).ToString(@"mm\:ss");
            }
            else
            {
                timeLabel.Content = TimeSpan.FromSeconds(time).ToString(@"mm\:ss");
            }

            if (time >= 60* timerLength)
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

        private void resetButton_Click(object sender, RoutedEventArgs e)
        {
            timer.Stop();
            time = 0;
            timeLabel.Content = TimeSpan.FromSeconds(time).ToString(@"mm\:ss");
        }

        private void settingsButton_Click(object sender, RoutedEventArgs e)
        {
            settingsWindow windowForSettings = new settingsWindow();
            windowForSettings.Topmost = true;
            windowForSettings.Show();
        }

        private void timeIsUp()
        {
            System.Media.SystemSounds.Exclamation.Play();
            Window1 notificationWindow = new Window1();
            notificationWindow.Topmost = true;
            notificationWindow.Show();
            time = -60 * waitLength;
        }

        
    }
}
