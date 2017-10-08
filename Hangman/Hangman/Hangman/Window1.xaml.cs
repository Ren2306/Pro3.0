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

namespace Hangman
{
	/// <summary>
	/// Interaction logic for Window1.xaml
	/// </summary>
	public partial class Window1 : Window
	{
		public Window1()
		{
			InitializeComponent();
		}

		private void btnSubmit_Click(object sender, RoutedEventArgs e)
		{
			Random rnd = new Random();
			int ranNum = Convert.ToInt32(rnd.Next(0, 50));
			string[] Movies = { "" };
			string[] Cars = { " " };
			string[] Animals = {"rat", "lion", "monkey", "alligator", "elephant", "chimpanzee", "crocodile", "aardvark", "armadillo", "pangolin", "basilisk", "barracuda", "aphid", "koala", "lungfish", "chimaera", "nightingale", "oribi", "ptarmigan"  };
			string[] Celebrities = { " " };
			string cmb = cmbCategory.SelectedItem.ToString();
			if(cmb == "Movies")
			{
				txtJumbled.Text = Convert.ToString (Movies[ranNum]);
				//ADD SCORE
			}
			else if (cmb == "Cars")
			{
				txtJumbled.Text = Convert.ToString(Cars[ranNum]);
				//ADD SCORE
			}
			else if (cmb == "Animals")
			{
				txtJumbled.Text = Convert.ToString(Animals[ranNum]);
				//ADD SCORE
			}
			else if (cmb == "Celebrities")
			{
				txtJumbled.Text = Convert.ToString(Celebrities[ranNum]);
				//ADD SCORE
			}
			else
			{
				MessageBox.Show("Please select a category");
			}
				
		}
	}
}
