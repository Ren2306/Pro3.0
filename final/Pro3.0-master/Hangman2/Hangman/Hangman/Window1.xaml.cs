using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Resources;
using System.Windows.Shapes;
using System.Windows.Threading;
using System.IO;

namespace Hangman
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public  bool muteB = true;
        private DispatcherTimer timer;
        private DateTime TimerStart;
        private HangmanAvatar Hangman;
        private Player Player;
        private FileHelper helper;
        private enum HangmanState { stage1, stage2, stage3, stage4, stage5, final_stage }
        private HangmanState CurrentState;
        private string Category;
        private int CurrentWord;
        private int WordsCounter; //Used to count how many words the user got (used to determine if user won)
        public Window1(Player p)
        {
            InitializeComponent();
            // LoopSound();
            timer = new DispatcherTimer();
            Player = p;
            txtUser.Content = $"Welcome {p.Username}";
            init();
        }

        void init()
        {
            if (Category != null)
            {
                txtTime.Content = "02:00";
                helper = new FileHelper(Category);
                Random rnd = new Random();
                int random_start = rnd.Next(helper.WordCount());
                CurrentWord = random_start;
                TimerStart = DateTime.Now.AddMinutes(2);
                timer.Interval = TimeSpan.FromSeconds(1);
                timer.IsEnabled = true;
                timer.Tick += dispatcherEvent;
                Hangman = new HangmanAvatar(image);
                txtCategory.Content = Category;
                txtTime.Foreground = Brushes.White;
                msgSelect_Cat.Visibility = Visibility.Hidden;
                txtJumbled.Visibility = Visibility.Visible;
                txtPrompt.Visibility = Visibility.Visible;
                txtScore.Content = 0;
                txtJumbled.Content = helper.JumbledWords[CurrentWord];
                tabControl.SelectedIndex = 1;
                WordsCounter = 0;
            }
        }

        private void dispatcherEvent(object sender, EventArgs e)
        {
            TimeSpan currentValue = TimerStart - DateTime.Now;
            updateTime(currentValue);

            if (currentValue.Seconds == 0 && currentValue.Minutes == 0)
            {
                timer.IsEnabled = false;
                MessageBoxResult result = MessageBox.Show("Try Again?", "OOPS! Time's Up.", MessageBoxButton.YesNo);

                if (result == MessageBoxResult.Yes)
                {
                    ResetGame();
                }
                else
                {
                    new MainWindow().Show();
                    this.Close();
                }
            }

        }

        public void ResetGame()
        {
            Hangman.Reset();
            TimerStart = DateTime.Now.AddMinutes(2);
            txtTime.Foreground = Brushes.White;
            timer.IsEnabled = false;
            CurrentState = HangmanState.stage1;
            txtTime.Content = "02:00";
            tabControl.SelectedIndex = 0;
            txtScore.Content = 0;
            txtJumbled.Content = "";
            WordsCounter = 0;
        }

        private void updateTime(TimeSpan count_down)
        {
            if (count_down.Minutes == 0 && count_down.Seconds <= 10)
            {
                txtTime.Foreground = Brushes.Red;
            }

            txtTime.Content = $"0{count_down.Minutes}:{count_down.Seconds}";
        }

        private void LoopSound()
        {
            Uri soundfile = new Uri("pack://application:,,,/happysound.wav");
            StreamResourceInfo sound = Application.GetResourceStream(soundfile);
            SoundPlayer a = new SoundPlayer(sound.Stream);
            if (muteB == true)
            {
                a.PlayLooping();
            } else
            {
                a.Stop();
            }
           
        }
        private void correct()
        {
            Uri soundfile = new Uri("pack://application:,,,/correct.wav");
            StreamResourceInfo sound = Application.GetResourceStream(soundfile);
            SoundPlayer b = new SoundPlayer(sound.Stream);
            if (muteB == true)
            {
            b.PlaySync();
            }
            else
            {

            }


        }
        private void incorrect()
        {
            Uri soundfile = new Uri("pack://application:,,,/incorrect.wav");
            StreamResourceInfo sound = Application.GetResourceStream(soundfile);
            SoundPlayer c = new SoundPlayer(sound.Stream);
            if (muteB == true)
            {
            c.PlaySync();
            }
            else
            {

            }

        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {

                case Key.Enter:

                    if (Category != null && !txtJumbled.Content.Equals(""))
                    {
                        string word = helper.Words[CurrentWord];
                        string answer = txtAnswer.Text;
                        if (word.ToLower().Equals(answer.ToLower()))
                        {
                            txtAnswer.Text = "";
                            Player.Score += 50;
                            txtScore.Content = Convert.ToString(Player.Score);
                            helper.Words.RemoveAt(CurrentWord);
                            helper.JumbledWords.RemoveAt(CurrentWord);
                            correct();
                            LoopSound();

                            if (helper.WordCount() == 0)
                            {
                                timer.IsEnabled = false;

                                MessageBoxResult result = MessageBox.Show($"You got {WordsCounter} words\nPlay again?", "You won!!", MessageBoxButton.YesNo);

                                if (result == MessageBoxResult.Yes)
                                {
                                    ResetGame();
                                }
                                else
                                {
                                    new MainWindow().Show();
                                    this.Close();
                                }
                            }
                            Random rnd = new Random();
                            int random_start = rnd.Next(0, helper.WordCount());
                            CurrentWord = random_start;
                            WordsCounter += 1;
                            txtJumbled.Content = helper.JumbledWords[CurrentWord];

                        }
                        else
                        {
                            CurrentState += 1;
                            incorrect();
                            LoopSound();
                            if (CurrentState <= HangmanState.final_stage)
                            {
                                Hangman.ChangeImage((int)CurrentState);
                            }
                            else
                            {
                                timer.IsEnabled = false;

                                MessageBoxResult result = MessageBox.Show($"You got {WordsCounter} words\nTry again?", "OOPS! You lost", MessageBoxButton.YesNo);

                                if (result == MessageBoxResult.Yes)
                                {
                                    ResetGame();
                                }
                                else
                                {
                                    new MainWindow().Show();
                                    this.Close();
                                }
                            }
                        }
                    }

                    break;
              

            }

        }

        private void Window_KeyUp(object sender, KeyEventArgs e)
        {

        }

        private void cmbCategory_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string cat = cmbCategory.SelectedItem.ToString();
            Category = cat.Substring(cat.LastIndexOf(' '));
            string s = "";
            foreach (char l in Category)
            {
                if (l != ' ')
                {
                    s += l;
                }
            }
            Category = s;
            init();
        }

        private void btnHint_Click(object sender, RoutedEventArgs e)
        {

            string jumbled = (string)txtJumbled.Content;

            if (Category == "Movies") // this is under hint button in Renisha's code.
            {

                switch (CurrentWord)
                {
                    case 0: MessageBox.Show("Popular horror movie about a clown"); break;
                    case 1: MessageBox.Show("Giant great white shark"); break;
                    case 2: MessageBox.Show("Superhero film based on Marvel Comics character of the same name"); break;
                    case 3: MessageBox.Show("An archetypal feral child raised in the African jungle"); break;
                    case 4: MessageBox.Show("Clownfish is captured in the Great Barrier Reef"); break;
                    case 5: MessageBox.Show("A rogue experiment leaves the antihero with accelerated healing powers"); break;
                    case 6: MessageBox.Show("Romantic comedy film directed by Griffin Dunne"); break;
                    case 7: MessageBox.Show("2004 American comedy heist film"); break;
                    case 8: MessageBox.Show("3 chipmunks undergo a series of misunderstanding"); break;
                    case 9: MessageBox.Show("Based on the novel by Veronica Roth"); break;
                    case 10: MessageBox.Show("A doctor discovers he can communicate with animals"); break;
                    case 11: MessageBox.Show("Supernatural horror film directed by John R. Leonetti"); break;
                    case 12: MessageBox.Show("Follows the life and murder of an American rapper"); break;
                    case 13: MessageBox.Show("Comedy drama directed by Stanley Kramer"); break;
                    case 14: MessageBox.Show("A rat that can cook makes an unusual alliance with a kitchen worker"); break;
                    case 15: MessageBox.Show("Classic film directed by Billy Wilder"); break;
                    case 16: MessageBox.Show("American historical film co-produced Steven Sielberg"); break;
                    case 17: MessageBox.Show("Four animals are unaware of what wildlife really is"); break;
                    case 18: MessageBox.Show("1942 American romantic film directed by Michael Curtiz"); break;
                    case 19: MessageBox.Show("A man works for an unpleasant guru of a Scientology-like movement"); break;
                    default: break;
                }
            }
            else if (Category == "Cars")
            {
                switch (CurrentWord)
                {
                    case 0: MessageBox.Show("German based company which produces automobiles and motorcycles"); break;
                    case 1: MessageBox.Show("Small economy car produced by the British Motor Corporation"); break;
                    case 2: MessageBox.Show("One of the best selling cars since 1974"); break;
                    case 3: MessageBox.Show("One of the most affordable cars to own"); break;
                    case 4: MessageBox.Show("Japanese multinational automobile manufacturer"); break;
                    case 5: MessageBox.Show("French mutinational automobile manufacturer established in 1899"); break;
                    case 6: MessageBox.Show("Small family car produced by the German manufacturer, Volkswagen"); break;
                    case 7: MessageBox.Show("South Korean multinational automobile manufacturer"); break;
                    case 8: MessageBox.Show("Automobile manufacturing division of Japanese transportation"); break;
                    case 9: MessageBox.Show("Japanese multinational automobile manufacturer"); break;
                    case 10: MessageBox.Show("Italian manufacturer of luxury supercars"); break;
                    case 11: MessageBox.Show("Italian luxury vehicle manufacturer established in 1914"); break;
                    case 12: MessageBox.Show("Global automobile manufacturer"); break;
                    case 13: MessageBox.Show("German automobile manufacturer of luxury cars"); break;
                    case 14: MessageBox.Show("Italian manufacturer of supercars and carbon fibres"); break;
                    case 15: MessageBox.Show("Britsh automobile company founded by Ron Dennis"); break;
                    case 16: MessageBox.Show("American automobile manufacturer headquartered in Dearborn"); break;
                    case 17: MessageBox.Show("French car manufacturer of high-performance automobiles"); break;
                    case 18: MessageBox.Show("German automobile manufacturer"); break;
                    case 19: MessageBox.Show("British multinational automobile manufacturer"); break;
                    case 20: MessageBox.Show("Britsh manufacturer and marketer of luxury cars and SUVs"); break;
                    default: break;
                }
            }
            else if (Category == "Animals")
            {
                switch (CurrentWord)
                {
                    case 0: MessageBox.Show("Medium sized, omnivorous rodents"); break;
                    case 1: MessageBox.Show("King of the jungle"); break;
                    case 2: MessageBox.Show("It has a wide, rounded snout and is black in colour"); break;
                    case 3: MessageBox.Show("Largest animal on the Earth"); break;
                    case 4: MessageBox.Show("Species of the Great apes in the genus Pan"); break;
                    case 5: MessageBox.Show("Medium sized, burrowing mammal native to Africa"); break;
                    case 6: MessageBox.Show("The word means Little armoured one in Spanish"); break;
                    case 7: MessageBox.Show("They have overlapping, keratin scales on their body"); break;
                    case 8: MessageBox.Show("Legendary reptile that is said to have the power to cause death in a single glance"); break;
                    case 9: MessageBox.Show("It's scientific name is Sphyraena"); break;
                    case 10: MessageBox.Show("Small sap-sucking insects"); break;
                    case 11: MessageBox.Show("Arboreal herbivorous animals native to Australia"); break;
                    case 12: MessageBox.Show("Although they aren't terrestrial animals, they are able to breathe in atmospheric oxygen"); break;
                    case 13: MessageBox.Show("They are informally know as ghost sharks"); break;
                    case 14: MessageBox.Show("They symbolize literature and poetry"); break;
                    case 15: MessageBox.Show("It's scientific name is Ourebia ourebi"); break;
                    case 16: MessageBox.Show("It is the official animal for the territory of Nunavat,Canada"); break;
                    case 17: MessageBox.Show("Legendary creature in the folklore of parts of America"); break;
                    default: break;
                }
            }
            else if (Category == "Celebrities")
            {
                switch (CurrentWord)
                {
                    case 0: MessageBox.Show("Born and raised in Houston, Texas and is 36 years old"); break;
                    case 1: MessageBox.Show("Started their career at the age of 19 in the film Endless love"); break;
                    case 2: MessageBox.Show("Born in New York City and starred in the film, Avengers as Black widow"); break;
                    case 3: MessageBox.Show("He began singing when he was just 6 years old"); break;
                    case 4: MessageBox.Show("Married to Ashton Kutchen"); break;
                    case 5: MessageBox.Show("He has a net worth of $240 million"); break;
                    case 6: MessageBox.Show("Talk show host, actress, producer and philanthropist"); break;
                    case 7: MessageBox.Show("One of her quotes are: Pink isn't just a colour, it's an attitude"); break;
                    case 8: MessageBox.Show("Hails from a family of wrestlers"); break;
                    case 9: MessageBox.Show("After singing for a church in her childhood, she pursued gospel music as a teenager"); break;
                    case 10: MessageBox.Show("American rapper, record producer and actor"); break;
                    case 11: MessageBox.Show("Made her screen debut as a child in Lookin' to get out"); break;
                    case 12: MessageBox.Show("Best known for his role as Chandler in the television sitcom, Friends"); break;
                    case 13: MessageBox.Show("Married to Simon Konecki"); break;
                    case 14: MessageBox.Show("Professional footballer who plays as a forward for Spanish club, Real Madrid and Portugal national team"); break;
                    case 15: MessageBox.Show("One of his quotes are: Well i have a microphone and you don't so you will listen to every damn word I have to say!"); break;
                    case 16: MessageBox.Show("Born in McComb, Mississippi and raised in Kentwood, Louisana"); break;
                    case 17: MessageBox.Show("Began his acting career in the sitcom, The 70's show"); break;
                    case 18: MessageBox.Show("Seventh most followed user on Instagram"); break;
                    case 19: MessageBox.Show("Married to James Righton"); break;
                }
            }
            else
            {
                // MessageBox.Show("Select a Category first");
            }
        }

        private void txtAnswer_GotFocus(object sender, RoutedEventArgs e)
        {
            txtAnswer.Text = "";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            HelpScreen hs = new HelpScreen();
            hs.Show();
        }

        private void button_Click_1(object sender, RoutedEventArgs e)
        {
            if (muteB == true)
            {
            muteB = false;
                LoopSound();
            }
            else
            {
                muteB = true;
                LoopSound();
            }

        }
    }
}
