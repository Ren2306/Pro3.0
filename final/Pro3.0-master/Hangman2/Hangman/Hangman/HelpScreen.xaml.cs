using System;
using System.Collections.Generic;
using System.IO;
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
    /// Interaction logic for HelpScreen.xaml
    /// </summary>
    public partial class HelpScreen : Window
    {
        public HelpScreen()
        {
            InitializeComponent();
            using (StreamReader sr = new StreamReader("Help.txt"))
            {
                List<string> list = new List<string>();
               

                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    list.Add(line);
                    helpClass hs = new helpClass(list);
                    txbHelp.Text = hs.ToString();
                }
            }

        }
        public class helpClass
        {
            List<string> lst;
               public  helpClass(List<string> lst)
            {
                this.lst = lst;

            }
            public  override string ToString()
            {
                string now = "";
                foreach (string str in lst)
                {
                    now += "\n"+str;
                       }
                return""+now;
            }
        }
        private void txbHelp_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
