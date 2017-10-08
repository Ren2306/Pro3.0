﻿using System;
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
			LoopSound();
		}

		private void LoopSound()
		{
            //Uri soundfile = new Uri("pack://application:,,,/Visager_-_04_-_Factory_Time.wav");
            //StreamResourceInfo sound = Application.GetResourceStream(soundfile);
            //SoundPlayer a = new SoundPlayer("pack://application:,,,/Visager_-_04_-_Factory_Time.wav");
            //a.PlayLooping();
        }

		private void btnPlay_Click(object sender, RoutedEventArgs e)
		{
			string[] Names = {"2306Ren" } ;
			int i;
			for (i = 0; i < Names.Length; i++)
			{
				if (txtUsername.Text == Names[i])
				{
					this.Hide();
					new Window1().Show();
				}
               else if (txtUsername.Text != Names[i])
                {
                    MessageBox.Show("Please register to play");
                }
            }
		
		}

		private void btnRegister_Click(object sender, RoutedEventArgs e)
		{
			this.Hide();
			new Window2().Show();
		}
	}
}
