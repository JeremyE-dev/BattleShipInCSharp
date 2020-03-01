using BattleShip.BLL.GameLogic;
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

        public void FirstTurn()
        {

        }

        public void TrackTurn()
        {

        }

        public void ProcessTurn()
        {

        }

        public void setP1Board(Board b)
        {
            P1Board = b;
        }


        public void setP2Board(Board b)
        {
            P2Board = b;
        }

        public string[,] createShotHistoryGrid()
        {
            string[,]shotHistoryGrid= new string [10,10];

            //fill 2d array with "*";

            for (int i = 0; i < shotHistoryGrid.GetLength(0); i++)
            {
                for (int j = 0; j < shotHistoryGrid.GetLength(0); j++)
                {
                    shotHistoryGrid[i,j] = "*";
                }

            }

            return shotHistoryGrid;

        }

        //updates shot history, displays grid
        public void processShot ()
        {
            // get shot from player 1 input
            // create new instance of coordinate object
            // set the x and y values of that coordinate object to input from player
            // is there a ship at that location: check board to see if there is a ship at this location
            // if there is, .... PICK up Here
        }

        //asks player for shot, validates it, then returns a coordinate
        public void GetShotFromPlayer()
        {
            //while
            Console.Write("Enter the location that you would like to fire at (Ex: \"B2\") :  ");
            Console.ReadLine();
            
            String locationEntered = Console.ReadLine();
            String letterofRow = locationEntered.Substring(0, 1);
            String numberOfColumn = locationEntered.Substring(1);
            
            
            
            
            
            //end while
  
        }

        //START HERE 3/2/20
        //takes in a string converts it to a number

        public int ValidateRow(string row)
        {
            int convertedRow;
            string lower = row.ToLower();

            while (true)
            {
               
                lower = Console.ReadLine().ToLower();

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
                        convertedRow= 4;
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

                    default:
                        Console.WriteLine("Invlaid input, please try again");
                        continue;

                }
                Console.WriteLine();

                return convertedRow;
            }







        }

        //validates that the can be converted to an int
        public void ValidateColumn() 
        {

        }




    }
}
