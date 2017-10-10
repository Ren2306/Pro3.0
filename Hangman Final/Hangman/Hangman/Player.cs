using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hangman
{
    class Player
    {
        public string Username { get; set; }
        public int Score { get; set; }

        public Player(string name, int score)
        {
            Username = name;
            Score = score;
        }

        public Player(string name)
        {
            Username = name;
            Score = 0;
        }


    }
}
