namespace MineSweeper
{
    using System;
    using System.Linq;

    internal class Board
    {
        private const char Mine = '*';

        private readonly string[] cells;

        public Board(string space)
        {
            if (null == space) throw new ArgumentNullException("space");

            cells = space.Split("\n".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
        }

        public int Length
        {
            get { return cells.Length; }
        }

        public int MineCount
        {
            get { return cells.Sum(l => l.Count(c => c == Mine)); }
        }

        public int Width
        {
            get { return cells.Length > 0 ? cells[0].Length : 0; }
        }

        public string this[int line, int col]
        {
            get
            {
                return HasMineAt(line, col) ? new string(Mine, 1) : CellValue(line, col);
            }
        }

        public bool Contains(int line, int col)
        {
            return (0 <= line && line < Length) && (0 <= col && col < Width);
        }

        public bool HasMineAt(int line, int col)
        {
            return Contains(line, col) && cells[line][col] == Mine;
        }

        public override string ToString()
        {
            var result = new System.Text.StringBuilder(Length * Width);
            for (var l = 0; l < Length; l++)
            {
                for (var c = 0; c < Width; c++)
                {
                    result.Append(this[l, c]);
                }
                result.Append('\n');
            }
            return result.ToString();
        }

        private string CellValue(int line, int col)
        {
            var sum = 0;
            for (var l = line - 1; l <= line + 1; l++)
                for (var c = col - 1; c <= col + 1; c++) 
                    if (HasMineAt(l, c)) sum++;
            return Convert.ToString(sum);
        }
    }
}