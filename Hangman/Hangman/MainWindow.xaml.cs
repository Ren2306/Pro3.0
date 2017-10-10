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

            Uri soundfile = new Uri("pack://application:,,,/gamesound.wav");
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
            string[] Names = { "2306Ren" };
            int i;
            for (i = 0; i < Names.Length; i++)
            {
                if (txtUsername.Text == Names[i])
                {
                    Window1 a = new Window1();
                    a.Show();
                    this.Close();
                }
            }
            //if (txtUsername.Text != Names[i])
            //{
            //    MessageBox.Show("Please register to play");
            //}
        }

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            Window2 b = new Window2();
            b.Show();
            this.Close();
        }

        private void txtUsername_GotFocus(object sender, RoutedEventArgs e)
        {
            txtUsername.Text = "";
            string  a = "just checking something";
        }
    }
}
