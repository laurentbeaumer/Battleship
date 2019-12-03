namespace Battleship
{
    public struct Point
    {
        public int Row;

        public int Column;

        public override string ToString()
        {
            return string.Format("[{0},{1}]", Row, Column);
        }
    }
}
