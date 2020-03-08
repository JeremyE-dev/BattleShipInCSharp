using BattleShip.BLL.GameLogic;
using BattleShip.BLL.Requests;
using BattleShip.BLL.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BattleShip.UI
{

    class GameWorkFlow
    {
        private Board P1Board; // this is the board that has been previously setup by player1
        private Board P2Board; // "" by player 2
        private string CurrentPlayerName;
        private Board OpponentsBoard;
        private Board CurrentPlayersBoard;
        private string[,] CurrentPlayerShotHistoryGrid;
        private string Player1;
        private string Player2;
        private string[,] Player1ShotHistoryGrid;
        private string[,] Player2ShotHistoryGrid;
        private bool IsThereAVictory = false;
        private bool ContinueGame;

        // sets value of a random number between 1 and 2
        // sets Currentplayer Name and Board to that player, sets opponents board to opposite players board
        public GameWorkFlow()
        {
            Player1ShotHistoryGrid = new string[10, 10];
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    Player1ShotHistoryGrid[i, j] = "*";

                }

            }

            Player2ShotHistoryGrid = new string[10, 10];
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    Player2ShotHistoryGrid[i, j] = "*";

                }

            }

        }
        public void FirstTurn()
        {


            Random rand = new Random();
            int x = rand.Next(1, 3); //number between 1 and 2

            switch(x)
            {
                case 1: // player 1 goes first
                    CurrentPlayerName = Player1;
                    CurrentPlayersBoard = P1Board;
                    CurrentPlayerShotHistoryGrid = Player1ShotHistoryGrid;
                    OpponentsBoard = P2Board;
                    Console.WriteLine("{0} You will go first", CurrentPlayerName);
                    break;

                case 2: //player 2 goes first
                    CurrentPlayerName = Player2;
                    CurrentPlayersBoard = P2Board;
                    CurrentPlayerShotHistoryGrid = Player2ShotHistoryGrid;
                    OpponentsBoard = P1Board;
                    Console.WriteLine("{0} You will go first", CurrentPlayerName);
                    break;
                    
            }

        }

        public void SetPlayer1(string name)
        {
            Player1 = name;
        }

        public void SetPlayer2(string name)
        {
            Player2 = name;
        }

        // check who current player is, then swaps current player and board information
        public void TrackTurn() // switch players
        {
            


            if (CurrentPlayerName.Equals(Player1))
            {
                Console.WriteLine("{0}, its your turn", Player2);
                CurrentPlayerName = Player2;
                CurrentPlayersBoard = P2Board;
                CurrentPlayerShotHistoryGrid = Player2ShotHistoryGrid;
                OpponentsBoard = P1Board;

            }

            else if (CurrentPlayerName.Equals(Player2))
            {
                Console.WriteLine("{0}, its your turn", Player1);
                CurrentPlayerName = Player1;
                CurrentPlayersBoard = P1Board;
                CurrentPlayerShotHistoryGrid = Player1ShotHistoryGrid;
                OpponentsBoard = P2Board;
            }

            else
            {
                Console.WriteLine("Player Tracking Error: ");
            }
          

        }

        public void ProcessTurn()
        {
            //show the playera grid with marks from their boards shot history
            ////Place yellow "M" in a coordinate if shot if fired and missed
            ////Place red "H" if a shot has been fired upon and hit
            printShotHistoryGrid();

            //prompt user for coordinate entry
            //validate entry - create coord obj, convert letter to num call opponents boards fireshot method
            //retreive response from FireShot method and display appropriate message to user
            processShot();
        }

        public void setP1Board(Board b)
        {
            P1Board = b;
        }


        public void setP2Board(Board b)
        {
            P2Board = b;
        }

        //print the CURRENT PLAYERS GRID 
        public void printShotHistoryGrid()
        {
           
            string[] RowLetters = { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J" };
            Console.WriteLine("Here is your shot history Grid: ");
            Console.WriteLine();

            Console.WriteLine("  1 2 3 4 5 6 7 8 9 10"); 
            for (int i = 0; i < 10; i++)
            {
                string row = RowLetters[i];
                Console.Write("{0} ", row);
                for (int j = 0; j < 10; j++)
                {
                    if (CurrentPlayerShotHistoryGrid[i, j] == "H")
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write(CurrentPlayerShotHistoryGrid[i, j] + " ");
                        Console.ResetColor();
                    }
                    else if (CurrentPlayerShotHistoryGrid[i, j] == "M")
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write(CurrentPlayerShotHistoryGrid[i, j] + " ");
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.Write(CurrentPlayerShotHistoryGrid[i, j] + " ");
                    }


                }
                Console.WriteLine();
            }

            Console.WriteLine();

        }
        public void processShot ()
        {
            while (true)
            {

                //create coord object and call get shot
                // update shot history grid based on repsonse
                Coordinate c = GetShotFromPlayer();
                FireShotResponse response = OpponentsBoard.FireShot(c);

                ShotStatus status = response.ShotStatus;

                switch (status)
                {
                    case ShotStatus.Duplicate:
                        Console.WriteLine("You Have tried this location before, please enter another location");
                        continue; //repeat turn

                    case ShotStatus.Invalid:
                        Console.WriteLine("Invalid shot, please enter another location");
                        continue; //repeat trun

                    case ShotStatus.Hit:
                        CurrentPlayerShotHistoryGrid[c.XCoordinate -1, c.YCoordinate -1] = "H";
                        Console.WriteLine("You hit one of your opponents ships, next players turn");
                        break; //do not repeat turn


                    case ShotStatus.Miss:
                        CurrentPlayerShotHistoryGrid[c.XCoordinate -1 , c.YCoordinate -1] = "M";
                        Console.WriteLine("You missed, next players turn");
                        break; //do not repeat turn

                    case ShotStatus.HitAndSunk:
                        CurrentPlayerShotHistoryGrid[c.XCoordinate-1, c.YCoordinate-1] = "H";
                        Console.WriteLine("You sunk a {0}", response.ShipImpacted);
                        break; //do not repeat turn

                    case ShotStatus.Victory:
                        CurrentPlayerShotHistoryGrid[c.XCoordinate-1, c.YCoordinate-1] = "H";
                        Console.WriteLine("VICTORY! {0} YOU SUNK ALL OF YOUR OPPONENTS SHIPS", CurrentPlayerName);
                        IsThereAVictory = true;
                        break; //do not repeat turn

                }

                Console.WriteLine("press any key to continue");
                Console.ReadKey();
                Console.Clear();            
                break;

            }
         

        }
 
        //asks player for shot, validates it, returns a coordinate
        public Coordinate GetShotFromPlayer()
        {
            int ValidatedRow = 0;
            int ValidatedColumn = 0;
            Coordinate coor;

            while (true) 
            { 
            Console.Write("Enter a location to fire upon (Ex: \"B2\") :  ");
            String locationEntered = Console.ReadLine();

            if (String.IsNullOrEmpty(locationEntered) || locationEntered.Length < 2 || locationEntered.Length > 3)
                {
                    Console.WriteLine("Invalid number of characters, please try again");
                    continue;
                }
            
            //asert true:  the userinput is at least 2 characters,not more than three, and not null
                String letterofRow = locationEntered.Substring(0, 1);
                String numberOfColumn = locationEntered.Substring(1);

            //Validate if first character is a letter between a and j
            if(ValidateRow(letterofRow))
                {
                    ValidatedRow = ConvertRowToNumber(letterofRow);
                    
                }
            
            else
                {
                    Console.WriteLine("Invalid Row: Please Try Again");
                    continue;
                }

             //validate if column was a number betwen 1 and 10
            int output;
            if ( int.TryParse(numberOfColumn,  out output))
                {
                    if (output >= 1 && output <= 10)
                    {
                        ValidatedColumn = output ; 
                        break;
                    }

                    else
                    {
                        Console.WriteLine("the Column was not between 1 and 10, please try again");
                        continue;
                    }
                }
            else
                {
                    Console.WriteLine("That was not a number, please try again");
                    continue;
                }


            }
            coor = new Coordinate(ValidatedRow, ValidatedColumn);
            
            return coor;
        }

        
        //takes in a string converts it to a number
        public bool ValidateRow(string row)
        {
            string lower = row.ToLower();

            while (true)
            {

                switch (lower)
                {
                    case "a":
                        
                    case "b":

                        
                    case "c":

                    case "d":

                    case "e":

                    case "f":

                    case "g":

                    case "h":

                    case "i":

                    case "j":
                        return true;
                        

                    default:
                        return false;

                }
             
            }

        }

        //takes in a string a - j, converst to number 1-10
        public int ConvertRowToNumber(string row)
        {
            int convertedRow = 0;
            string lower = row.ToLower();

             switch (lower)
            {
                case "a":
                    convertedRow = 1;
                    break;
                case "b":
                    convertedRow = 2;
                    break;

                case "c":
                    convertedRow = 3;
                    break;

                case "d":
                    convertedRow = 4;
                    break;

                case "e":
                    convertedRow = 5;
                    break;

                case "f":
                    convertedRow = 6;
                    break;

                case "g":
                    convertedRow = 7;
                    break;

                case "h":
                    convertedRow = 8;
                    break;

                case "i":
                    convertedRow = 9;
                    break;

                case "j":
                    convertedRow = 10;
                    break;

            }
            Console.WriteLine();
            return convertedRow;    
            
        }

        public bool CheckForVictory ()
        {
            if (IsThereAVictory)
            {
                
                Console.WriteLine("Would you like to play again? enter Y for yes and N to quit: ");
                string YesOrNo = Console.ReadLine();
                YesOrNo = YesOrNo.ToLower();

                while (true)
                {
                    if (YesOrNo == "y")
                    {
                        ContinueGame = true;
                        Console.Clear();
                        break;                     
                    }

                    else if (YesOrNo == "n")
                    {
                        ContinueGame = false;
                        Console.WriteLine("Thank you for Playing!");
                        Console.ReadLine();
                        System.Environment.Exit(0);
                    }

                    else
                    {
                        Console.WriteLine("Invalid Response, please try again");
                        Console.WriteLine();
                    }

                }


            }


            return ContinueGame;

        }
    }
}
