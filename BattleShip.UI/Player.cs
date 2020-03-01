using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip.UI
{
    class Player
    {
        private string Player1;
        private string Player2;

        
        public Player(string name1, string name2)
        {
            Player1 = name1;
            Player2 = name2;
        }

   
        
        public string GetPlayer1()
        {
            return Player1;
        }

        public string GetPlayer2()
        {
            return Player2;
        }

        public void SetPlayer1 (string userInput)
        {
            Player1 = userInput;
        }

        public void SetPlayer2(string userInput)
        {
            Player2 = userInput;
        }
    }
}
