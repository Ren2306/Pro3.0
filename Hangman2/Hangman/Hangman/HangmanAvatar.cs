using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace Hangman
{
    class HangmanAvatar
    {

        string inThisProject = "pack://application:,,,/";

        private BitmapImage[] images;

        private Image Hangman;

        public HangmanAvatar(Image hangman)
        {
            images = new BitmapImage[] {
                    new BitmapImage(new Uri(inThisProject + "hanger.png")),
                    new BitmapImage(new Uri(inThisProject + "hangman_stage0.png")),
                    new BitmapImage(new Uri(inThisProject + "hangman_stage1.png")),
                    new BitmapImage(new Uri(inThisProject + "hangman_stage2.png")),
                    new BitmapImage(new Uri(inThisProject + "hangman_stage3.png")),
                    new BitmapImage(new Uri(inThisProject + "hangman_stage4.png")),
                    new BitmapImage(new Uri(inThisProject + "hangman_stage5.png")) };

            Hangman = hangman;
            Hangman.Source = images[0];

        }

        public void Reset()
        {
            Hangman.Source = images[0];
        }

        public void AddLimb(int state)
        {
            Hangman.Source = images[state];
        }
    }
}
