using System;
using System.Collections.Immutable;
using System.ComponentModel.Design.Serialization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;

namespace NoughtsAndCrossesConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Random r = new Random();
            var firstPerson = r.Next(1, 3);
            Console.WriteLine("Enter your name Player One");
            var playerOneName = Console.ReadLine();
            Console.WriteLine("Enter your name Player Two");
            var playerTwoName = Console.ReadLine();
            var playerOne = new Player(playerOneName, (GridSymbols.O), 0);
            var playerTwo = new Player(playerTwoName, (GridSymbols.X), 0);
            var grid = new GameGrid();
            grid.GridInit();
            Console.WriteLine(grid);
            Thread.Sleep(1500);
            while ((playerOne.Win == false) || (playerTwo.Win == false))
            {
                if (firstPerson == 1) 
                {//player one first
                    grid.PlayerMove(playerOne);
                    Console.WriteLine(grid);
                    Console.Clear();
                    Console.WriteLine(grid);
                    grid.PlayerMove(playerTwo);
                    Console.WriteLine(grid);
                    Console.Clear();
                    Console.WriteLine(grid);
                }
                if (firstPerson != 1)
                {//player two first
                    grid.PlayerMove(playerTwo);
                    Console.WriteLine(grid);
                    Console.Clear();
                    Console.WriteLine(grid);
                    grid.PlayerMove(playerOne);
                    Console.WriteLine(grid);
                    Console.Clear();
                    Console.WriteLine(grid);
                }
                

            }
            

            
            
               
               

            
        }



    }


    public enum GridSymbols
    {
        X = 1,
        O = 2,
        U = 3,

    }

    public class Player
    {
        public string PlayerName { get; }
        public GridSymbols PlayerSymbol { get; }
        
        public int Position { get; set; }
        public bool Win { get; set; }

        public Player(string playerName, GridSymbols playerSymbol, int firstOrSecond)
        {
            PlayerName = playerName;
            PlayerSymbol = playerSymbol;
            Win = false;
        }
    }
    public class GameGrid
    {
        public GridSymbols[,] Grid = new GridSymbols[3, 3];
        private int[] UsedSpaces = new int[0];


        public void GridInit()
        {
            for (var i = 0; i < 3; i++)
            {
                for (var j = 0; j < 3; j++)
                {
                    Grid[i, j] = GridSymbols.U;
                }
            }






        }

        public int[] PlayerMove(Player player)
        {
            int totCount = 1;
            var numberValdiation = false;
            var position = 0;
            while (numberValdiation == false)
            {


                Console.WriteLine($"{player.PlayerName}, Enter the position of where you want to go? (1-9)");
                var userInputPosition = Console.ReadLine();
                if (!int.TryParse(userInputPosition, out position))
                {
                    Console.WriteLine("Please enter a valid number (1-9)");
                    
                }
                
                player.Position = position;
                Console.WriteLine(UsedSpaces.Length);
                if (UsedSpaces.Length != 0)
                {
                    
                    for (var i=0;i==(UsedSpaces.Length-1);i++)
                    {
                        if (UsedSpaces[i] == player.Position)
                        {
                            Console.WriteLine($"{player.PlayerName} please enter a number which hasn't been chosen from (1-9)");

                        }



                    }
                    
                }

                numberValdiation = true;
                
                
            }



            for (var i = 0; i < 3; i++)
            {
                for (var j = 0; j < 3; j++)
                {

                    if (totCount == player.Position)
                    {
                      if (Grid[i, j] == GridSymbols.U) 
                        {
                            numberValdiation = true;
                            Grid[i, j] = player.PlayerSymbol;
                            UsedSpaces.Append(player.Position);
                            Console.WriteLine(UsedSpaces.Length);
                        }
                        else
                        {
                            Console.WriteLine($"I am sorry {player.PlayerName} but someone has already gone there so please choose a different position");
                            Thread.Sleep(1500);
                            PlayerMove(player);
                        }





                        var noOfSpacesUsed = 0;
                        for (var y = 0; y < 3; y++)
                        {
                            for (var x = 0; x < 3; x++)

                            {
                                if ((Grid[y, x] == GridSymbols.X) || (Grid[y, x] == GridSymbols.O))
                                { noOfSpacesUsed++; 
                                }
                            }
                        }
                        if (noOfSpacesUsed == 9)
                        {
                            Console.WriteLine("Game Over; its a tie!, no one wins!");
                            Thread.Sleep(2500);
                            Environment.Exit(0);
                        }
                        //add change to for tie game over, checking each space, if a player symbol add
                        Grid[i, j] = player.PlayerSymbol;
                    }

                    totCount++;

                }
            }

            return UsedSpaces;
            
        }

        public void WinChecks(Player player)
        {
             
            
                
                for (var i = 0; i < 3; i++)
                {
                    if ((Grid[i, 0] == player.PlayerSymbol) && (Grid[i, 1] == player.PlayerSymbol)&&(Grid[i, 2] == player.PlayerSymbol))
                    {
                    player.Win = true;
                    Console.WriteLine($"Congratulations {player.PlayerName}! You won with a Row!");
                    }
                if ((Grid[0, i] == player.PlayerSymbol) && (Grid[1, i] == player.PlayerSymbol) && (Grid[2, i] == player.PlayerSymbol))
                {
                    player.Win = true;
                    Console.WriteLine($"Congratulations {player.PlayerName}! You won with a Row!");

                }



            }
            

            
        }


       


        public override string ToString()
        {

            return $"({Grid[0, 0]}) | ({Grid[0, 1]}) | ({Grid[0, 2]}) {Environment.NewLine}" +
                   $"----|-----|-----{Environment.NewLine}" +
                   $"({Grid[1, 0]}) | ({Grid[1, 1]}) | ({Grid[1, 2]}) {Environment.NewLine}" +
                   $"----|-----|-----{Environment.NewLine}" +
                   $"({Grid[2, 0]}) | ({Grid[2, 1]}) | ({Grid[2, 2]}) {Environment.NewLine}";
                   
                        

        }

    }
}




