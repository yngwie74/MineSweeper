namespace MineSweeper
{
    using System;

    public static class Game
    {
        public static void Solve(string space)
        {
            var board = new Board(space);
            Console.Write(board);
        }
    }

    internal class Program
    {
        private static void Main(string[] args)
        {
            const string Space = "*...\n"
                               + "....\n"
                               + ".*..\n"
                               + "....\n";

            Game.Solve(Space);

            Console.ReadLine();
        }
    }
}