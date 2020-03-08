using BattleShip.BLL.GameLogic;
using BattleShip.BLL.Requests;
using BattleShip.BLL.Ships;


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip.UI
{
    // This class:
    // creates instance of a board
    // collects coordinate, direction, and ShipType from player
    // attempts to place ship on players board, and places on board if a valid entry

    class SetupWorkFlow
    {
        private int _row;
        private int _column;
        private ShipDirection _direction;
        private ShipType _type;
        private Board _setUpBoard;




        //creates a Board instance for GameWorkFlow
        //with ships populated by the user

        //Each player is prompted to place ships by giving coordinate and direction, // i
        public SetupWorkFlow()
        {
            _row = 0;
            _column = 0;
            _setUpBoard = new Board();

        }


        //get shiptype from player if valid input

        public ShipType GetShipTypeFromPlayer()
        {


            while (true)
            {
                Console.Write("Please enter the type of ship you would like to place:\n D = Destroyer (2 spaces)," +
                "Cr = Cruiser (3 spaces), S = Submarine (3 spaces),  B = Battleship (4 spaces), Ca = Carrier (5 spa" +
                "ces):  ");


                string lower = Console.ReadLine().ToLower();

                switch (lower)
                {
                    case "d":
                        _type = ShipType.Destroyer;
                        break;

                    case "s":
                        _type = ShipType.Submarine;
                        break;

                    case "cr":
                        _type = ShipType.Cruiser;
                        break;

                    case "b":
                        _type = ShipType.Battleship;
                        break;

                    case "ca":
                        _type = ShipType.Carrier;
                        break;



                    default:
                        Console.WriteLine("Invlaid input, please try again");
                        continue;

                }
                Console.WriteLine();

                return _type;
            }




        }


        //if valid input, sets row to int value of given row selected by player, returns int value of row
        public int GetRowFromPlayer()
        {

            string lower = "";

            while (true)
            {
                Console.Write("enter ROW of ship you would like to place (A-J):  ");
                lower = Console.ReadLine().ToLower();

                switch (lower)
                {
                    case "a":
                        _row = 1;
                        break;

                    case "b":
                        _row = 2;
                        break;

                    case "c":
                        _row = 3;
                        break;

                    case "d":
                        _row = 4;
                        break;

                    case "e":
                        _row = 5;
                        break;

                    case "f":
                        _row = 6;
                        break;

                    case "g":
                        _row = 7;
                        break;


                    case "h":
                        _row = 8;
                        break;

                    case "i":
                        _row = 9;
                        break;

                    case "j":
                        _row = 10;
                        break;

                    default:
                        Console.WriteLine("Invlaid input, please try again");
                        continue;

                }
                Console.WriteLine();

                return _row;
            }

        }

        //if valid input, sets column field of given column selected by player, returns value of column
        public int GetColumnFromPlayer()
        {
           
            int output = 0;

            while (true)
            {
                Console.Write("enter COLUMN of ship you would like to place (1 - 10):  ");
                string inputColumn = Console.ReadLine();

                if (int.TryParse(inputColumn, out output))
                {
                    if (output >= 1 && output <= 10)
                    {
                        _column = output;
                        break;
                    }

                    else
                    {
                        Console.WriteLine("That number was not between 1 and 10!");
                        Console.WriteLine("--------");
                       
                        
                    }


                }

                else
                {
                    Console.WriteLine("That was not a number!");
                    Console.WriteLine("--------");
                    
                }
            }

            Console.WriteLine();
            return _column;

           

        }

        //if valid input, sets ship direction to UP, Dow, Left, or Right and returns the ship direction
        public ShipDirection GetDirectionFromPlayer()
        {


            while (true)
            {
                Console.Write("Please Enter a direction ( U, D, L, R) for your ship U = UP, D = Down, R = Right, L = Left:  ");
                string lower = Console.ReadLine().ToLower();


                switch (lower)
                {
                    case "u":
                        return _direction = ShipDirection.Up;


                    case "d":
                        return _direction = ShipDirection.Down;


                    case "l":
                        return _direction = ShipDirection.Left;

                    case "r":
                        return _direction = ShipDirection.Right;


                    default:
                        Console.WriteLine("That is invalid input, please try again");
                        break;

                }

            }
            


        }

        // creates coordinate object, sets X, Y fields to row and columns 
        //set by GetRowFromPlayer and GetColumnFromPlayer
        public PlaceShipRequest CreateRequest()
        {

            PlaceShipRequest request = new PlaceShipRequest();
            request.Coordinate = new Coordinate(_row, _column);
            request.Direction = _direction;
            request.ShipType = _type;

            return request;
        }


        public Board PlaceAllPlayerShips()
        {
            int numberOfShipsPlaced = 0;

            while (numberOfShipsPlaced < 1) //CHANGE Back to 5
            {


                GetShipTypeFromPlayer();
                GetRowFromPlayer();
                GetColumnFromPlayer();
                GetDirectionFromPlayer();
                Console.WriteLine();
                PlaceShipRequest r = CreateRequest();

                if (_setUpBoard.PlaceShip(r) == BLL.Responses.ShipPlacement.Ok)
                {
                    numberOfShipsPlaced++;
                    Console.WriteLine("successful ship placement," +
                        " Total ships placed: {0}  " +
                        "Place {1} more", numberOfShipsPlaced, 5 - numberOfShipsPlaced);
                                            
                        Console.WriteLine();

                }

                else
                {
                    Console.WriteLine("That was not a valid ship placement, please try again");
                    Console.WriteLine();
                }


            }

            //ReportShipsPlaced();
            Console.WriteLine("You have place all 5 of your ships");
            Console.WriteLine("Press any key to clear the screen");
            Console.ReadKey();
            Console.Clear();
            
            return _setUpBoard;



        }

        //not currently used, but may add later
        public void ReportShipsPlaced()
        {
            Console.WriteLine("You have place all 5 of your ships");
            Console.WriteLine("Here are a list of ships and coordinates you have placed");
            
           //print out board positions
           //foreach(Coordinate x in _setUpBoard.Ship.B)
            
            
            
 
            
            foreach (Ship x in _setUpBoard.Ships)
            {
              
              Console.WriteLine("Here are a list of ships and coordinates you have placed");
                

              Console.WriteLine("You have placed a {0} at the following coordinates: ", x.ShipName);

            
                // look slike Board Positions is an array of coordinates
                foreach(Coordinate y in x.BoardPositions)
                {
                    Console.WriteLine("Row: " + y.XCoordinate + " " +  "Column: " + y.YCoordinate);
                 
                }

            }
        }


    }
}



