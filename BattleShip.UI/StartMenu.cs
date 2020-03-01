using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip.UI
{
    class StartMenu
    {
        string Player1;
        string Player2;



        //Displays initial welcome message
        
        public string GetPlayer1()
        {
            return Player1;
        }

        public string GetPlayer2()
        {
            return Player2;
        }
        
        
        public void Welcome()
        {
            Console.WriteLine("Welcome to BattleShip, press any key to start the game");
            Console.ReadKey();

        }

        //asks for names from user, stores both names in player object
        public void EnterNames ()
        {
            
            
            Console.WriteLine("There are two players in this game");
            
            Console.WriteLine("Player 1, please enter your name: ");
            // validate - cannot be null, enter at least one letter
            Player1 = Console.ReadLine();

            Console.WriteLine("Player 2, please enter your name: ");
            // validate - cannot be null, enter at least one letter
            Player2 = Console.ReadLine();

            //why does it stop here and not move to next line
           Console.WriteLine("Welcome {0} and {1}, Let's Play BattleShip", Player1, Player2);
           Console.WriteLine();
           
           //Player players = new Player(Player1, Player2);

           

        }

     

        //Displays Instructions for the game
        public void Instructions()
        {
            Console.WriteLine("Each player will set their own 10 x 10 gameboard with 5 ships that take up a set amount of spaces on the board");
            Console.WriteLine();
            Console.WriteLine("Each player has 1 of each: Carrier(5 spaces), BattleShip(4 spaces), Submarine(3 spaces), " +
                "Cruiser( 3 spaces), Destroyer(2 spaces)");
            Console.WriteLine();
            Console.WriteLine("Ships can be placed perpendicular (not diagonal), anywhere on the board and are not allowed to overlap");
            Console.WriteLine();
            Console.WriteLine("Rows of the grid are denoted by letters A - J and colums by the numbers 1- 10");
            Console.ReadLine();
        }

        public void SetBoardMessage(string name)
        {
            Console.WriteLine("****{0} , you will now set your board****", name);
            Console.WriteLine("You will place a total of 5 ships");
            Console.WriteLine();

           

        }

      

        public void StartGame()
        {
            Welcome();
            EnterNames();
            Instructions();
        }
    }
}
