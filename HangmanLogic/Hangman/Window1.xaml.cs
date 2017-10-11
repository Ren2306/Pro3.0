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
        int index;
		string cmb;
		BitmapImage[] Criminal;
		int count = 0;
		int i = 0;
		public Window1()
		{
			InitializeComponent();
			//LoopSound();
			/*play(); */                                      // another problem here
			string path = "pack://application:,,,/";
			Criminal = new BitmapImage[]
{
                new BitmapImage(new Uri(path + "hangman_stage0.png")),
                new BitmapImage(new Uri(path +"hangman_stage1.png")),
                new BitmapImage(new Uri(path +"hangman_stage2.png")),
                new BitmapImage(new Uri(path +"hangman_stage3.png")),
                new BitmapImage(new Uri(path +"hangman_stage4.png")),
                new BitmapImage(new Uri(path +"hangman_stage5.png"))
};
			updateview();
		}

		private void updateview()
		{
			image.Source = Criminal[count]; // the changing of pictures
		}

		private void correctorwrong()
		{
			switch (count)
			{
				case 0: count = 1; break;
				case 1: count = 2; break;  //change of pictures
				case 2: count = 3; break;
				case 3: count = 4; break;
				case 4: count = 5; MessageBox.Show("You Lost", "try better next time", MessageBoxButton.OK, MessageBoxImage.Exclamation); break;

				default:
					break;
			}
		}

		private void LoopSound()
		{

			Uri soundfile = new Uri("pack://application:,,,/gamesound.wav");
			StreamResourceInfo sound = Application.GetResourceStream(soundfile);
			SoundPlayer a = new SoundPlayer(sound.Stream);
			a.Play();
		}

		private void updateLevel()
		{
			if (i % 2 == 0)
			{
				txtLevel.Text += 1;
			}
		}

		private void play()
		{
			//Arrays that store words from different categories
			string[] Movies = { "It", "Jaws", "Iron man", "Tarzan", "Finding nemo", "Deadpool", "The accidental husband", "Oceans 12", "Alvin and the chipmunks", "Divergent", "Dr Dolittle", "Anabelle", "Notorious", "Guess whos coming for dinner", "Ratatouille", "Sunset boulevard", "Schinders List", "Madagascar", "Casablanca", "Schizopolis" };
			string[] MoviesJ = { "tI", "wasJ", "nIor amn", "aranzT", "dinnFgi oNme", "eDopioda", "heT", "cidlenAatc usabdHn", "21 sanecO", "dan ksuciphnm het nAliv", "reverDign", "rD letilDto", "lebAneal", "rotsiNou", "seuGs show omgicn ofr nrinde", "tRelliuaoat", "uneStsn vardlebou", "hindSscier stil", "agasMadrac", "aaCsablcna", "oliSchipso" };
			string[] Cars = { "BMW", "Mini", "Corolla", "Datsun", "Nissan", "Renault", "Golf", "Hyundai", "Subaru", "Mazda", "Lamborghini", "Maserati", "Mercedes Benz", "Audi", "Pagani", "Mclaren", "Ford", "Bugatti", "Volkswagen", "Rolls Royce", "Bently" };
			string[] CarsJ = { "MWB", "inMi", "roaCllo", "atuDns", "nisNsa", "naelRut", "loGf", "yHandiu", "bauSur", "zaMad", "bahigiLamnr", "atMistaer", "dMseecre zeBn", "duAi", "gaaPin", "lacMrne", "dFro", "guitBat", "swagVekoln", "lolsR coRye", "yeBltn" };
			string[] Animals = { "Rat", "Lion", "Monkey", "Alligator", "Elephant", "Chimpanzee", "Crocodile", "Aardvark", "Armadillo", "Pangolin", "Basilisk", "Barracuda", "Aphid", "Koala", "Lungfish", "Chimaera", "Nightingale", "Oribi", "Ptarmigan", "Chupacabra" };
			string[] AnimalsJ = { "aRt", "iLon", "rotlAlgia", "peltahEn", "epemihazCn", "rocliedCo", "raaAkdvr", "madAllior", "lingonaP", "lisksaBi", "Buraracda", "hAdpi", "alaoK", "hLusinfg", "areamihC", "ttanglieiNgh", "ribOi", "maginratP", "braachupCa" };
			string[] Celebrities = { " Beyonce", "Tom Cruise", "Scarlett Johansson", "Usher", "Mila Kunis", "Brad Pitt", "Oprah Winfrey", "Miley Cyrus", "Dwayne Johnson", "Katy Perry", "Eminem", "Angelina Jolie", "Matthew Perry", "Adele", "Christiano Ronaldo", "Adam Sandler", "Britney Spears", "Ashton Kutcher", "Kim Kardashian", "Keira Knightly" };
			string[] CelebritiesJ = { "conyBee", "omT sieruC", "telracSt sosnhaoJn", "hsUer", "laiM sKinu", "arBd itPt", "harpO yinfWre", "lieMy yCsur", "nayDwe nosnoJh", "taKy reryP", "minEem", "liegAna lieoJ", "hetwtMa rreyP", "ledeA", "roatsCihin onoRadl", "aAmd laneSrd", "yenitrB raspeS", "Atonhs hcreKtu", "imK idKraanahs", "riKea thylgiKn" };

            int score;
            if (txtScore.Text == null || txtScore.Text == "")
            {
                score = 0;
            }
            else
            {
                score = Convert.ToInt32(txtScore.Text); // doesnt have a score if u just registered. brings up a exception
            }
            string answer = txtAnswer.Text;
            if (i < 20 && count < 5)                                                      // problem here
            {
                if (index == 0)
                {
                    txtJumbled.Text = Convert.ToString(MoviesJ[i]);
                    if (answer == Movies[i])
                    {
                        score += 50;
                        txtJumbled.Text = Convert.ToString(MoviesJ[i + 1]);
                        txtAnswer.Clear();
                        updateLevel();

                    }
                    else if (String.IsNullOrWhiteSpace(txtAnswer.Text) == true)
                    {
                        MessageBox.Show("Please enter answer in the space provided");

                    }
                    else
                    {
                        if (count == 5)
                        {
                            MessageBox.Show("Oh no! Guess you'll have to start over");

                        }
                        else
                        {
                            MessageBox.Show("Incorrect answer, please try again");
                            count++;
                            updateview();

                        }
                    }
                }
                else if (index == 1)
                {
                    txtJumbled.Text = Convert.ToString(CarsJ[i]);
                    if (answer == Cars[i])
                    {
                        score += 50;
                        txtJumbled.Text = Convert.ToString(Cars[i + 1]);
                        txtAnswer.Clear();
                        updateLevel();
                    }
                    else if (String.IsNullOrWhiteSpace(txtAnswer.Text) == true)
                    {
                        MessageBox.Show("Please enter answer in the space provided");
                    }
                    else
                    {
                        if (count == 5)
                        {
                            MessageBox.Show("Oh no! Guess you'll have to start over");
                        }
                        else
                        {
                            MessageBox.Show("Incorrect answer, please try again");
                            updateview();
                            count++;
                        }

                    }
                }
            }
            else if (index == 2)
            {

                txtJumbled.Text = Convert.ToString(AnimalsJ[i]);
                if (answer == Animals[i])
                {
                    score += 50;
                    txtJumbled.Text = Convert.ToString(AnimalsJ[i + 1]);
                    txtAnswer.Clear();
                    updateLevel();
                }
                else if (String.IsNullOrWhiteSpace(txtAnswer.Text) == true)
                {
                    MessageBox.Show("Please enter answer in the space provided");
                }
                else
                {
                    if (count == 5)
                    {
                        MessageBox.Show("Oh no! Guess you'll have to start over");
                    }
                    else
                    {
                        MessageBox.Show("Incorrect answer, please try again");
                        updateview();
                        count++;
                    }
                }
            }
            else if (index == 3)
            {
                    txtJumbled.Text = Convert.ToString(CelebritiesJ[i]);
                    if (answer == Celebrities[i])
                    {
                        score += 50;
                        txtJumbled.Text = Convert.ToString(CelebritiesJ[i + 1]);
                        txtAnswer.Clear();
                        updateLevel();
                    }
           else if (String.IsNullOrWhiteSpace(txtAnswer.Text) == true)
                {
                    MessageBox.Show("Please enter answer in the space provided");
                }
           else
                {
                  if (i == 20 && count == 5)
                   {
                            MessageBox.Show("Oh no! Guess you'll have to start over");
                   }
              else
                   {
                            MessageBox.Show("Incorrect answer, please try again");
                            //change picture
                            count++;
                   }
                   }
                }
            else
            {
                MessageBox.Show("No category selected");
            }
			}

		private void btnPlay_Click(object sender, RoutedEventArgs e)
		{
			//Checks which category is selected
            index = cmbCategory.SelectedIndex;
			if (index == 0)
			{
				MessageBox.Show("Yippy, the category you have selected is Movies. Click on the play tab to continue");
               
			}
			else if (index == 1)
			{
				MessageBox.Show("Yippy, the category you have selected is Cars. Click on the play tab to continue");
			}
			else if (index == 2)
			{
				MessageBox.Show("Yippy, the category you have selected is Animals. Click on the play tab to continue");
			}
			else if (index == 3)
			{
				MessageBox.Show("Yippy, the category you have selected is Celebrities. Click on the play tab to continue");
			}
			else
			{
				MessageBox.Show("Please select a category");
			}
		}

		private void btnHint_Click(object sender, RoutedEventArgs e)
		{
			if (index == 0) 
			{
				switch (txtJumbled.Text)
				{
					case "tI": MessageBox.Show("Popular horror movie about a clown"); break;
					case "wasJ": MessageBox.Show("Giant great white shark"); break;
					case "nIor amn": MessageBox.Show("Superhero film based on Marvel Comics character of the same name"); break;
					case "aranT": MessageBox.Show("An archetypal feral child raised in the African jungle"); break;
					case "dinnFgi oNme": MessageBox.Show("Clownfish is captured in the Great Barrier Reef"); break;
					case "eDopioda": MessageBox.Show("A rogue experiment leaves the antihero with accelerated healing powers"); break;
					case "heT cidlenAatc": MessageBox.Show("Romantic comedy film directed by Griffin Dunne"); break;
					case "21 sanecO": MessageBox.Show("2004 American comedy heist film"); break;
					case "dan ksuciphnm het nAliv": MessageBox.Show("3 chipmunks undergo a series of misunderstanding"); break;
					case "reverDign": MessageBox.Show("Based on the novel by Veronica Roth"); break;
					case "rD letilDto": MessageBox.Show("A doctor discovers he can communicate with animals"); break;
					case "lebAneal": MessageBox.Show("Supernatural horror film directed by John R. Leonetti"); break;
					case "rotsiNbu": MessageBox.Show("Follows the life and murder of an American rapper"); break;
					case "seuGs show omgicn ofr nrinde": MessageBox.Show("Comedy drama directed by Stanley Kramer"); break;
					case "tRelhuaoat": MessageBox.Show("A rat that can cook makes an unusual alliance with a kitchen worker"); break;
					case "uneStsn vardlebou": MessageBox.Show("Classic film directed by Billy Wilder"); break;
					case "hindScier stil": MessageBox.Show("American historical film co-produced Steven Sielberg"); break;
					case "agasMadrac": MessageBox.Show("Four animals are unaware of what wildlife really is"); break;
					case "aaCsabcna": MessageBox.Show("1942 American romantic film directed by Michael Curtiz"); break;
					case "oliSchipso": MessageBox.Show("A man works for an unpleasant guru of a Scientology-like movement"); break;
					default: break;
				}
			}
			else if (index == 1)
			{
				switch (txtJumbled.Text)
				{
					case "MWB": MessageBox.Show("German based company which produces automobiles and motorcycles"); break;
					case "inMi": MessageBox.Show("Small economy car produced by the British Motor Corporation"); break;
					case "roaCllo": MessageBox.Show("One of the best selling cars since 1974"); break;
					case "atuDsn": MessageBox.Show("One of the most affordable cars to own"); break;
					case "nisNsa": MessageBox.Show("Japanese multinational automobile manufacturer"); break;
					case "naelRut": MessageBox.Show("French mutinational automobile manufacturer established in 1899"); break;
					case "loGf": MessageBox.Show("Small family car produced by the German manufacturer, Volkswagen"); break;
					case "yHandiu": MessageBox.Show("South Korean multinational automobile manufacturer"); break;
					case "bauSur": MessageBox.Show("Automobile manufacturing division of Japanese transportation"); break;
					case "zaMad": MessageBox.Show("Japanese multinational automobile manufacturer"); break;
					case "bahigiLomnr": MessageBox.Show("Italian manufacturer of luxury supercars"); break;
					case "atMistaer": MessageBox.Show("Italian luxury vehicle manufacturer established in 1914"); break;
					case "dMseecre zeBn": MessageBox.Show("Global automobile manufacturer"); break;
					case "duAi": MessageBox.Show("German automobile manufacturer of luxury cars"); break;
					case "gaaPin": MessageBox.Show("Italian manufacturer of supercars and carbon fibres"); break;
					case "lacMrne": MessageBox.Show("Britsh automobile company founded by Ron Dennis"); break;
					case "dFro": MessageBox.Show("American automobile manufacturer headquartered in Dearborn"); break;
					case "guitBat": MessageBox.Show("French car manufacturer of high-performance automobiles"); break;
					case "swagVekoln": MessageBox.Show("German automobile manufacturer"); break;
					case "lolsR coRyce": MessageBox.Show("British multinational automobile manufacturer"); break;
					case "yeBltn": MessageBox.Show("Britsh manufacturer and marketer of luxury cars and SUVs"); break;
					default: break;
				}
			}
			else if (index == 2)
			{
				switch (txtJumbled.Text)
				{
					case "aRt": MessageBox.Show("Medium sized, omnivorous rodents"); break;
					case "iLon": MessageBox.Show("King of the jungle"); break;
					case "rotlAgia": MessageBox.Show("It has a wide, rounded snout and is blakc in colour"); break;
					case "peltahEn": MessageBox.Show("Largest animal on the Earth"); break;
					case "epemihazCn": MessageBox.Show("Species of the Great apes in the genus Pan"); break;
					case "raaAkdvr": MessageBox.Show("Medium sized, burrowing mammal native to Africa"); break;
					case "madAllior": MessageBox.Show("The word means Little armoured one in Spanish"); break;
					case "lingonaP": MessageBox.Show("They have overlapping, keratin scales on their body"); break;
					case "lisksaBi": MessageBox.Show("Legendary reptile that is said to have the power to cause death in a single glance"); break;
					case "Buraracda": MessageBox.Show("It's scientific name is Sphyraena"); break;
					case "hAdpi": MessageBox.Show("Small sap-sucking insects"); break;
					case "alaoK": MessageBox.Show("Arboreal herbivorous animals native to Australia"); break;
					case "hLusinfg": MessageBox.Show("Although they aren't terrestrial animals, they are able to breathe in atmospheric oxygen"); break;
					case "areamihC": MessageBox.Show("They are informally know as ghost sharks"); break;
					case "ttanglieiNgh": MessageBox.Show("They symbolize literature and poetry"); break;
					case "ribOi": MessageBox.Show("It's scientific name is Ourebia ourebi"); break;
					case "maginratP": MessageBox.Show("It is the official animal for the territory of Nunavat,Canada"); break;
					case "braachupCa": MessageBox.Show("Legendary creature in the folklore of parts of America"); break;
					default: break;
				}
			}
			else
			{
				switch (txtJumbled.Text)
				{ 
					case "conyBee": MessageBox.Show("Born and raised in Houston, Texas and is 36 years old"); break;
					case "omT sieruC": MessageBox.Show("Started their career at the age of 19 in the film Endless love"); break;
					case "telracSt sosnhaoJn": MessageBox.Show("Born in New York City and starred in the film, Avengers as Black widow"); break;
					case "hsUer": MessageBox.Show("He began singing when he was just 6 years old"); break;
					case "laiM sKinu": MessageBox.Show("Married to Ashton Kutchen"); break;
					case "arBd itPt": MessageBox.Show("He has a net worth of $240 million"); break;
					case "harpO yinfWre": MessageBox.Show("Talk show host, actress, producer and philanthropist"); break;
					case "lieMy yCsur": MessageBox.Show("One of her quotes are: Pink isn't just a colour, it's an attitude"); break;
					case "nayDwe nosnoJh": MessageBox.Show("Hails from a family of wrestlers"); break;
					case "taKy reryP": MessageBox.Show("After singing for a church in her childhood, she pursued gospel music as a teenager"); break;
					case "minEem": MessageBox.Show("American rapper, record producer and actor"); break;
					case "lidgAna lieoJ": MessageBox.Show("Made her screen debut as a child in Lookin' to get out"); break;
					case "hetwtMa rreyP": MessageBox.Show("Best known for his role as Chandler in the television sitcom, Friends"); break;
					case "ledeA": MessageBox.Show("Married to Simon Konecki"); break;
					case "roatsCihin onoRadl": MessageBox.Show("Professional footballer who plays as a forward for Spanish club, Real Madrid and Portugal national team"); break;
					case "aAmd laneSrd": MessageBox.Show("One of his quotes are: Well i have a microphone and you don't so you will listen to every damn word I have to say!"); break;
					case "yenitrB raspeS": MessageBox.Show("Born in McComb, Mississippi and raised in Kentwood, Louisana"); break;
					case "Atonhs hcreKtu": MessageBox.Show("Began his acting career in the sitcom, The 70's show"); break;
					case "imK idKraanahs": MessageBox.Show("Seventh most followed user on Instagram"); break;
					case "riKea thylgiKn": MessageBox.Show("Married to James Righton"); break;
				}
			}

		}

		private void btnSubmit_Click(object sender, RoutedEventArgs e)
		{
			play();
			
        }

        private void txtAnswer_GotFocus(object sender, RoutedEventArgs e)
        {
            txtAnswer.Text = "";
        }
    }
	}

	
