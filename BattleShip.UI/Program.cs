using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BattleShip.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            StartMenu Game1 = new StartMenu();
            Game1.StartGame();

            SetupWorkFlow Player1Setup = new SetupWorkFlow();
            SetupWorkFlow Player2Setup = new SetupWorkFlow();
            
            GameWorkFlow GameFlow = new GameWorkFlow();

            Game1.SetBoardMessage(Game1.GetPlayer1());
           
            GameFlow.setP1Board(Player1Setup.PlaceAllPlayerShips());


            Game1.SetBoardMessage(Game1.GetPlayer2());
           
            GameFlow.setP2Board(Player2Setup.PlaceAllPlayerShips());

            Console.WriteLine();

        }

       
    }
}