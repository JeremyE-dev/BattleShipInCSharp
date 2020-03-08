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

            //WELCOMES PLAYERS, STORES PLAYER NAMES IN PLAYER OBJ
            while (true)
            {
            //WELCOMES PLAYERS, STORES PLAYER NAMES IN PLAYER OBJ
            Game1.StartGame();

            SetupWorkFlow Player1Setup = new SetupWorkFlow();
            SetupWorkFlow Player2Setup = new SetupWorkFlow();

            GameWorkFlow GameFlow = new GameWorkFlow();

            //INSTRUCTS PLAYER1 TO SET THEIR BOARD

            Game1.SetBoardMessage(Game1.GetPlayer1());

            //COLLECTS/VALIDATES DATA AND SETS THE BOARD FOR PLAYER 1/SETS P1Board in Gameflow TO THE SET BOARD
            GameFlow.setP1Board(Player1Setup.PlaceAllPlayerShips());


            //INSTRUCTS PLAYER 2 TO SET THEIR BOARD
            Game1.SetBoardMessage(Game1.GetPlayer2());

            //COLLECTS/VALIDATES DATA AND SETS THE BOARD FOR PLAYER 2/SETS P2Board in Gameflow TO THE SET BOARD
            GameFlow.setP2Board(Player2Setup.PlaceAllPlayerShips());

            //NOTE:  at this point Gameflow contains set boards for player 1 and player 2

            //SETS PLAYERS NAMES IN GAMEFLOW TO PLAYERS NAMES CREATED DURING SETUP
            GameFlow.SetPlayer1(Game1.GetPlayer1());
            GameFlow.SetPlayer2(Game1.GetPlayer2());

            //CHOOSES WHO GOES FIRST
            GameFlow.FirstTurn();
 
            while(true)
                {
                    //GETS A SHOT FROM PLAYER AND PROCESSES IT
                    // Displays current players shot history grid
                    // Calls process shot, which prompts player for a shot, and lets the player know if its a hit or miss
                    // updates players shot history (so next turns grid will display updated information) 
                   
                    GameFlow.ProcessTurn();

                    //check is victory, if true asks if players want to continue or quit
                    // if player wants to quit, the console program will end
                    // if player wants to play again; 

                    // if check for victory returns true, exit the loop and go back to top to start new game

                 
                    if (GameFlow.CheckForVictory()) // if true and player wants to quit game exits within the method via (System.Environment.Exit(0))
                    {
                        break; // this should exit the loop and start new game
                    }

                    //if check for victory returns false, continue to next turn
                    else
                    {
                        GameFlow.TrackTurn();
                        Console.WriteLine();
                    }
                    
                }
          
            }
        }

    }
}