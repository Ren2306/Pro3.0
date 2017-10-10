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
        List<string> words;
        public FileHelper(string file)
        {
            category = file+".txt";
            words = new List<string>();
            init();
        }

        private void init()
        {
            if (File.Exists(category))
            {
                StreamReader reader = File.OpenText(category);
                string line = reader.ReadLine();

                while (line != null)
                {
                    words.Add(line);
                    line = reader.ReadLine();
                }
            }
        }

        public List<string> JumbledWords()
        {
            List<string> JumbledWords = new List<string>();
            Random r = new Random();
            
            foreach (string word in words)
            {
                int size = word.Length - 1;
                string jumbled_word = "";
                for(int k=0; k<word.Length; k++)
                {
                    int idx = r.Next(0, size);
                    if(idx!= word.IndexOf(' '))
                    {
                        jumbled_word += word[idx];
                    }
                }
                JumbledWords.Add(jumbled_word);
            }

            return JumbledWords;
        }
    }
}
