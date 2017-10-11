using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Hangman
{
    class FileHelper
    {
        string category;
        public List<string> Words { get; private set; }
        public List<string> JumbledWords { get; private set; }

        public FileHelper(string word_file)
        {
            category = word_file + ".txt";
            Words = new List<string>();
            JumbledWords = new List<string>();
            init_words();
            init_jwords();
        }

        private void init_words()
        {
            if (File.Exists(category))
            {
                StreamReader reader = File.OpenText(category);
                string line = reader.ReadLine();

                while (line != null)
                {
                    Words.Add(line);
                    line = reader.ReadLine();
                }
                reader.Close();
            }

        }

        private void init_jwords()
        {
            if (File.Exists(category))
            {
                StreamReader reader = File.OpenText(category);
                string line = reader.ReadLine();

                while (line != null)
                {
                    Random r = new Random();
                    string jword = "";
                    int size = line.Length;
                    int randomIndex = r.Next(2, size);
                    int halfway = (size / 2);
                    int i = size - 1;
                    int x = 0;

                    for (int k = 0; k < size; k++)
                    {

                        if ((k+1) % 2 == 0)
                        {

                            jword += line[i];
                            i--;
                        }
                        else
                        {
                            jword += line[x];
                            x++;
                        }

                    }
                    JumbledWords.Add(jword);
                    line = reader.ReadLine();
                }

                reader.Close();
            }
        }


        public int WordCount()
        {
            return Words.Count;
        }
    }
}
