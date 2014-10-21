namespace MineSweeper
{
    using System;
    using System.Linq;

    using NUnit.Framework;

    [TestFixture]
    public class BoardTests
    {
        [Test]
        public void ParseNullBoard()
        {
            const string Space = null;

            Assert.That(() => new Board(Space), Throws.InstanceOf<ArgumentNullException>());
        }

        [Test]
        public void ParseDegenerateBoard()
        {
            const string Space = "";

            var board = new Board(Space);

            Assert.That(board.Length, Is.EqualTo(0), "Length");
            Assert.That(board.Width, Is.EqualTo(0), "Width");
            Assert.That(board.MineCount, Is.EqualTo(0), "MineCount");
        }

        [Test]
        public void Parse1x1EmptyBoard()
        {
            const string Space = ".";

            var board = new Board(Space);

            Assert.That(board.Length, Is.EqualTo(1), "Length");
            Assert.That(board.Width, Is.EqualTo(1), "Width");
            Assert.That(board.MineCount, Is.EqualTo(0), "MineCount");
        }

        [Test]
        public void Parse1x1With1Mine()
        {
            const string Space = "*";

            var board = new Board(Space);

            Assert.That(board.Length, Is.EqualTo(1), "Length");
            Assert.That(board.Width, Is.EqualTo(1), "Width");
            Assert.That(board.MineCount, Is.EqualTo(1), "MineCount");
        }

        [Test]
        public void Parse4x4EmptyBoard()
        {
            var space = "    \n".Repeat(4);

            var board = new Board(space);

            Assert.That(board.Length, Is.EqualTo(4), "Length");
            Assert.That(board.Width, Is.EqualTo(4), "Width");
            Assert.That(board.MineCount, Is.EqualTo(0), "MineCount");
        }

        [Test]
        public void Parse4x4With2Mines()
        {
            const string Space = "*   \n" + "    \n" + "  * \n" + "    \n";

            var board = new Board(Space);

            Assert.That(board.Length, Is.EqualTo(4), "Length");
            Assert.That(board.Width, Is.EqualTo(4), "Width");
            Assert.That(board.MineCount, Is.EqualTo(2), "MineCount");
        }

        [Test]
        public void HasMineAt_1x1EmptyBoard()
        {
            const string Space = ".";

            var board = new Board(Space);

            Assert.That(board.HasMineAt(0, 0), Is.False);
        }

        [Test]
        public void HasMineAt_1x1With1Mine()
        {
            const string Space = "*";

            var board = new Board(Space);

            Assert.That(board.HasMineAt(0, 0), Is.True);
        }

        [Test, Sequential]
        public void HasMineAt_4x41With2Mines(
            [Values(0, 1, 2, 3)] int line,
            [Values(0, 1, 2, 3)] int col,
            [Values(false, true, false, true)] bool expected)
        {
            const string Space = "....\n"
                               + ".*..\n"
                               + "....\n"
                               + "...*\n";

            var board = new Board(Space);

            Assert.That(board.HasMineAt(line, col), Is.EqualTo(expected));
        }

        [Test]
        public void Contains([Range(-1, 1)] int line, [Range(-1, 1)] int col)
        {
            const string Space = "*";

            var board = new Board(Space);

            Assert.That(board.Contains(line, col), Is.EqualTo(line == 0 && col == 0));
        }

        [Test]
        public void HasMineAt_OutOfBounds_ShouldBeFalse()
        {
            const string Space = "*";

            var board = new Board(Space);

            Assert.That(board.HasMineAt(-1, -1), Is.False);
        }

        [Test, Sequential]
        public void CellValue_TrivialCase([Values(".", "*")] string space, [Values("0", "*")] string expected)
        {
            Assert.That(new Board(space)[0, 0], Is.EqualTo(expected));
        }

        [Test]
        public void CellValue_1x2With1Mine()
        {
            const string Space = "*.";

            var board = new Board(Space);

            Assert.That(board[0, 1], Is.EqualTo("1"));
        }

        [Test]
        public void ToString_1x2With1Mine()
        {
            const string Space = "*.";
            const string Expected = "*1\n";

            var board = new Board(Space);

            Assert.That(board.ToString(), Is.EqualTo(Expected));
        }

        [Test]
        public void AcceptanceCriteria()
        {
            const string Space    = "*...\n"
                                  + "....\n"
                                  + ".*..\n"
                                  + "....\n";

            const string Expected = "*100\n"
                                  + "2210\n"
                                  + "1*10\n"
                                  + "1110\n";

            var board = new Board(Space);

            Assert.That(board.ToString(), Is.EqualTo(Expected));
        }
    }

    internal static class Utils
    {
        public static string Repeat(this string element, int count)
        {
            return string.Join(string.Empty, Enumerable.Repeat(element, count));
        }
    }
}