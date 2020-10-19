using System;

namespace NoughtsAndCrossesConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
             var winner = false;
            Console.WriteLine("Enter your name Player One");
            var playerOneName = Console.ReadLine();
            Console.WriteLine("Enter your name Player Tne");
            var playerTwoName = Console.ReadLine();
            var playerOne= new Player(playerOneName,(GridSymbols.O));
            var playerTwo= new Player(playerTwoName,(GridSymbols.X));
            var grid = new GameGrid();
            grid.GridInit();
            while ( winner==false)
            {
                grid.PlayerMove(playerOne);
                Console.Clear();
                Console.WriteLine(grid);
                grid.PlayerMove(playerTwo);
                Console.Clear();
                Console.WriteLine(grid);
            }


        }
    }

    public enum GridSymbols
    {
        X=1,
        O=2,

    }

    public class Player
    {
        public string PlayerName { get;  }
        public GridSymbols PlayerSymbol { get;  }

        public Player(string playerName, GridSymbols playerSymbol)
        {
            PlayerName = playerName;
            PlayerSymbol = playerSymbol;
        }
    }
    public class GameGrid
    {
        private string[,] Grid =new string[3,3];

        public void GridInit()
        {
            for (var i = 0; i < 3; i++)
            {
                for (var j = 0; j < 3; j++)
                {
                    Grid[i, j] = "~";
                }
            }
        }

        public void PlayerMove(Player player)
        {
            var numberValdiation = false;
            while (numberValdiation == false)
            {

                int totCount = 1;
                Console.WriteLine($"{player.PlayerName}, Enter the position of where you want to go? (1-9)");
                var userInputPosition = Console.ReadLine();
                if (!int.TryParse(userInputPosition, out var position))
                {
                    Console.WriteLine("Please enter a valid number (1-9)");
                }

                numberValdiation = true;

                for (var i = 0; i < 3; i++)
                {
                    for (var j = 0; j < 3; j++)
                    {
                        if (totCount == position)
                        {
                            Grid[i, j] = $"{player.PlayerSymbol}";
                        }

                        totCount++;
                    }
                }
            }

        }
        public override string ToString()
        {
            return $"({Grid[0, 0]}) | ({Grid[0, 1]}) | ({Grid[0,2]}) {Environment.NewLine}" +
                   $"----|-----|-----{Environment.NewLine}"+
                   $"({Grid[1, 0]}) | ({Grid[1, 1]}) | ({Grid[1,2]}) {Environment.NewLine}" +
                   $"----|-----|-----{Environment.NewLine}"+
                   $"({Grid[2, 0]}) | ({Grid[2, 1]}) | ({Grid[2,2]}) {Environment.NewLine}";}
        }



}
