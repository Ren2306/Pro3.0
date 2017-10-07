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
using System.Windows.Resources;
using System.Media;

namespace project
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
            LoopSound();
            
        }
         private void LoopSound()
        {
            Uri soundfile = new Uri("pack://application:,,,/Visager_-_04_-_Factory_Time.wav");
            StreamResourceInfo sound = Application.GetResourceStream(soundfile);
            SoundPlayer a = new SoundPlayer("pack://application:,,,/Visager_-_04_-_Factory_Time.wav");
            a.PlayLooping();
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
