namespace Battleship
{
    public class Board
    {
        public readonly int Size = 10;
        public readonly Square[,] Matrix;

        public Board()
        {
            Matrix = new Square[Size, Size];
        }

        public Board(int size)
        {
            Size = size;
        }

        public Board Clone()
        {
            var board = new Board(Size);
            for (var i = 0; i < Size; i++)
                for (var j = 0; j < Size; j++)
                    board.Matrix[i, j] = new Square { Occupied = Matrix[i, j].Occupied, Hit = Matrix[i, j].Hit };
            return board;
        }
    }
}
