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
        }

        private void btnPlay_Click(object sender, RoutedEventArgs e)
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

            int i;

            for (i = 0; i < Names.Length; i++)
            {
                if (username.Text == Names[i])
                {
                    Window1 c = new Window1();
                    c.Show();
                    this.Close();
                }
            }
            if (!Names.Contains(username.Text))
            {
                MessageBox.Show("Please register to play");
            }

        }

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            Window2 b = new Window2();
            b.Show();
            this.Close();
        }
    }
}
