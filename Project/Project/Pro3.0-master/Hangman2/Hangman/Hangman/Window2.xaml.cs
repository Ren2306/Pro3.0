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
using System.IO;

namespace Hangman
{
	/// <summary>
	/// Interaction logic for Window2.xaml
	/// </summary>
	public partial class Window2 : Window
	{
		public Window2()
		{
			InitializeComponent();
		}

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            using (StreamWriter sw = File.AppendText("users.txt"))
            {
                sw.WriteLine("\n" + txtUsername.Text);

            }
            MessageBox.Show("You have been registered!");
            MainWindow a = new MainWindow();
            a.Show();
            this.Close();
        }

        private void btnHelp_Click(object sender, RoutedEventArgs e)
        {
            // fill in help button
        }

        private void txtUsername_GotFocus(object sender, RoutedEventArgs e)
        {
            txtUsername.Text = "";
        }
    }
}
