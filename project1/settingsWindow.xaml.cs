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
using System.Windows.Shapes;

namespace project1
{
    /// <summary>
    /// Interaction logic for Window2.xaml
    /// </summary>
    public partial class settingsWindow : Window
    {
        public settingsWindow()
        {
            InitializeComponent();
            //currentTime.Content = Properties.Settings.Default.timerLength;
            //currentWaitTime.Content = Properties.Settings.Default.waitLength;
            waitSlider.Value = Properties.Settings.Default.waitLength;
            timeSlider.Value = Properties.Settings.Default.timerLength;
            saveButton.Background = Brushes.Gray;
        }

        private void updateWaitTime(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            saveButton.Background = Brushes.Green;
            if (waitSlider.Value == Properties.Settings.Default.waitLength && timeSlider.Value == Properties.Settings.Default.timerLength)
            {
                saveButton.Background = Brushes.Gray;
            }
        }

        private void updateTime(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            saveButton.Background = Brushes.Green;
            if (waitSlider.Value == Properties.Settings.Default.waitLength && timeSlider.Value == Properties.Settings.Default.timerLength)
            {
                saveButton.Background = Brushes.Gray;
            }
        }

        private void settingsClicked(object sender, RoutedEventArgs e)
        {
            Properties.Settings.Default.timerLength = (int)timeSlider.Value;
            Properties.Settings.Default.waitLength = (int)waitSlider.Value;
            Properties.Settings.Default.Save();
            saveButton.Background = Brushes.Gray;
        }
    }
}
