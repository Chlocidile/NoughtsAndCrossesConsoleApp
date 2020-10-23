using System;
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
            var playerOne= new Player(playerOneName,(GridSymbols.O),0);
            var playerTwo= new Player(playerTwoName,(GridSymbols.X),0);
            if (firstPerson == 1)
            {
                playerOne.FirstORSecond = 1;
                playerTwo.FirstORSecond = 2;
            }

            if (firstPerson != 1)
            {
                playerOne.FirstORSecond = 2;
                playerTwo.FirstORSecond = 1;
            }
            var grid = new GameGrid();
            var win = false;
            grid.GridInit();
            Console.WriteLine(grid);
            while (win == false)
            {
                for (var i = 1; i != 3; i++)
                {
                    if (i == 1)
                    {
                        grid.PlayerMove(playerOne);
                        win = grid.WinChecks(playerOne);
                        Console.WriteLine(grid);
                    }

                    if (i != 1)
                    {
                        grid.PlayerMove(playerTwo);
                        win = grid.WinChecks(playerTwo);
                        Console.WriteLine(grid);
                    }


                }
            }



        }
    }

    public enum GridSymbols
    {
        X=1,
        O=2,
        U=3,

    }

    public class Player
    {
        public string PlayerName { get;  }
        public GridSymbols PlayerSymbol { get;  }
        public int FirstORSecond { get; set; }

        public Player(string playerName, GridSymbols playerSymbol, int firstOrSecond)
        {
            PlayerName = playerName;
            PlayerSymbol = playerSymbol;
        }
    }
    public class GameGrid
    {
        public GridSymbols [,] Grid =new GridSymbols[3,3];
        private int[] UsedSpaces = new int[0];


        public void GridInit()
        {
            for (var i = 0; i < 3; i++)
            {
                for (var j = 0; j < 3; j++)
                {
                    Grid[i, j] =  GridSymbols.U;
                }
            }






        }

        public void PlayerMove(Player player)
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
                    continue;
                }

                if (UsedSpaces.Length == 0)
                {
                    break;
                }
                for (var i = UsedSpaces.Length; i!=0; i--)
                {
                    if (UsedSpaces[i] == position)
                    {
                        Console.WriteLine($"{player.PlayerName} please enter a number which hasn't been chosen from (1-9)");

                    }



                }
                numberValdiation = true;
            }



            for (var i = 0; i < 3; i++)
            {
                    for (var j = 0; j < 3; j++)
                    {

                        if (totCount == position)
                        {
                            Grid[i, j] = player.PlayerSymbol;
                            UsedSpaces.Append(position);
                            if (UsedSpaces.Length == 9)
                            {
                                Console.WriteLine("GameOver!, No winner!");
                                Thread.Sleep(1500);
                                Environment.Exit(0);
                            }
                        }

                        totCount++;
                    }
            }


        }

        public bool  WinChecks(Player player)
        {
            var win = false;
            for (var i = 0; i < 3; i++)
            {

                if ((Grid[i, 0] == player.PlayerSymbol) & (Grid[i, 1] == player.PlayerSymbol) &
                    (Grid[i, 2] == player.PlayerSymbol))
                {
                    switch (i)
                    {
                        case 0:
                            Console.WriteLine($"{player.PlayerName} won! they got three in a row in the First Column");
                            win = true;
                            break;
                        case 1:
                            Console.WriteLine($"{player.PlayerName} won! they got three in a row in the First Column");
                            win = true;
                            break;
                        case 2:
                            Console.WriteLine($"{player.PlayerName} won! they got three in a row in the First Column");
                            win = true;
                            break;

                    }

                    ;
                    if ((Grid[0, i] == player.PlayerSymbol) & (Grid[1, i] == player.PlayerSymbol) &
                        (Grid[2, i] == player.PlayerSymbol))
                    {
                        switch (i)
                        {
                            case 0:
                                Console.WriteLine($"{player.PlayerName} won! they got three in a row in the First Row");
                                win = true;
                                break;
                            case 1:
                                Console.WriteLine($"{player.PlayerName} won! they got three in a row in the First Row");
                                win = true;
                                break;
                            case 2:
                                Console.WriteLine($"{player.PlayerName} won! they got three in a row in the First Row");
                                win = true;
                                break;

                        }

                        if (((Grid[0, 0] == player.PlayerSymbol) & (Grid[1, 1] == player.PlayerSymbol) &
                             (Grid[2, 2] == player.PlayerSymbol)) || ((Grid[2, 0] == player.PlayerSymbol) &
                                                                      (Grid[1, 1] == player.PlayerSymbol) &
                                                                      (Grid[0, 2] == player.PlayerSymbol)))
                        {
                            Console.WriteLine($"{player.PlayerName} won! They got three in a row diagonally");
                            win = true;
                        }



                    }


                }
            }

            return win;


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
