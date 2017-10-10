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
        BitmapImage[] Criminal;
        int currentstate = 0;  //change of pictures
        public Window1()
        {
            InitializeComponent();
            LoopSound();
            
            string path = "pack://application:,,,/";
            Criminal = new BitmapImage[]
{
                new BitmapImage(new Uri(path + "IMG-20170920-WA0001.jpg")),
                new BitmapImage(new Uri(path +"IMG-20170920-WA0002.jpg")),
                new BitmapImage(new Uri(path +"IMG-20170920-WA0003.jpg")),
                new BitmapImage(new Uri(path +"IMG-20170920-WA0004.jpg")),
                new BitmapImage(new Uri(path +"IMG-20170920-WA0000.jpg")),
                new BitmapImage(new Uri(path +"IMG-20170920-WA0005.jpg"))
};
            timer = new DispatcherTimer();
            TimerStart = DateTime.Now.AddMinutes(2);
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.IsEnabled = true;
            timer.Tick += dispatcherEvent;
            updateview();

            
        }

        private void updateview()
        {
            image.Source = Criminal[currentstate]; // the changing of pictures
        }

        private void correctorwrong ()
        {
            switch (currentstate)
            {
                case 0: currentstate = 1;break;
                case 1: currentstate = 2; break;  //change of pictures
                case 2: currentstate = 3;break;
                case 3: currentstate = 4;break;
                case 4: currentstate = 5;break;
                case 5: MessageBox.Show("You Lost", "try better next time", MessageBoxButton.OK, MessageBoxImage.Exclamation);break;

                default:
                    break;
            }
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
            a.Play();
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

        private void txtAnswer_GotFocus(object sender, RoutedEventArgs e)
        {
            txtAnswer.Text = "";
        }
    }
}
