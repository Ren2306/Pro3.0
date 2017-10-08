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
		public MainWindow()
		{
			InitializeComponent();
			//LoopSound();
		}

		private void LoopSound()
		{
           
            Uri soundfile = new Uri("pack://application:,,,/gamesound.wav");
			StreamResourceInfo sound = Application.GetResourceStream(soundfile);
			SoundPlayer a = new SoundPlayer(sound.Stream);
			a.PlayLooping();
		}

        private void btnPlay_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            new Window1().Show();
        }
    }
}
