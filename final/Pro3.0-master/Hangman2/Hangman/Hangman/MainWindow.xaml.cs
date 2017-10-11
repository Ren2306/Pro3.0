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
using System.Windows.Resources;
using System.Media;
using System.IO;

namespace Hangman
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        bool muteB = true;
        SoundPlayer a;
        public MainWindow()
        {

            InitializeComponent();
            LoopSound();
        }

        private void LoopSound()
        {

            Uri soundfile = new Uri("pack://application:,,,/happysound.wav");
            StreamResourceInfo sound = Application.GetResourceStream(soundfile);
            SoundPlayer a = new SoundPlayer(sound.Stream);
            if (muteB == true)
            {
                a.PlayLooping();
                muteB = false;
            }
            else
            {
                a.Stop();
                muteB = true;
            }
        }

        private void btnPlay_Click(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrWhiteSpace(username.Text) == true)
            {
                MessageBox.Show("Please a username or register", "Error : username not found", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                List<string> list = new List<string>();
                using (StreamReader reader = new StreamReader("users.txt"))
                {

                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        list.Add(line);
                    }
                }
                string[] Names = list.ToArray();

                if (!Names.Contains(username.Text))
                {
                    MessageBox.Show("Please register to play");
                }
                else
                {
                    Player p = new Player(username.Text);
                    Window1 c = new Window1(p);
                    c.Show();
                    this.Close();
                }
            }

        }

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            Window2 b = new Window2();
            b.Show();
            this.Close();
        }

        private void username_GotFocus(object sender, RoutedEventArgs e)
        {
            username.Text = "";
        }

        private void muteA_Click(object sender, RoutedEventArgs e)
        {
            LoopSound();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            HelpScreen hs = new HelpScreen();
            hs.Show();
        }
    }
}
