using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Resources;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Hangman
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        private DispatcherTimer timer;
        private DateTime TimerStart;
        public Window1()
        {
            InitializeComponent();
            timer = new DispatcherTimer();

            TimerStart = DateTime.Now.AddMinutes(2);
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.IsEnabled = true;
            timer.Tick += dispatcherEvent;

            LoopSound();
        }

        private void dispatcherEvent(object sender, EventArgs e)
        {
            TimeSpan currentValue = TimerStart - DateTime.Now;

            updateTime(currentValue);
        }

        private void updateTime(TimeSpan count_down)
        {

            txtTime.Content = $"0{count_down.Minutes}:{count_down.Seconds}";
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {

        }

        private void LoopSound()
        {

            Uri soundfile = new Uri("pack://application:,,,/gamesound.wav");
            StreamResourceInfo sound = Application.GetResourceStream(soundfile);
            SoundPlayer a = new SoundPlayer(sound.Stream);
            a.PlayLooping();
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {

            switch (e.Key)
            {

                case Key.Enter: break;

                case Key.P: break;

            }

        }

        private void Window_KeyUp(object sender, KeyEventArgs e)
        {

        }
    }
}
