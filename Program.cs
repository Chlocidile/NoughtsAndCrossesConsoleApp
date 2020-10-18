using System;

namespace NoughtsAndCrossesConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var grid = new GameGrid();
            grid.GridInit();

            Console.WriteLine((grid));

        }
    }

    public enum GridSymbols
    {
        X=1,
        O=2,

    }


    public class GameGrid
    {
        public string[,] Grid =new string[3,3];

        public void GridInit()
        {
            for (var i = 0; i < 3; i++)
            {
                for (var j = 0; j < 3; j++)
                {
                    Grid[i, j] = "~";
                }
            }s
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
