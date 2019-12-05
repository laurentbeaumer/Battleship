using System;

namespace Battleship
{
    public class Player
    {
        #region Properties
        public readonly int Size;
        public bool HasLost => hitpoints == 0; // Player has lost when points had dropped to zero

        private bool[,] ships;              // False if empty, True if occupied
        private bool[,] hits;               // True if was hit
        private int hitpoints = 0;             // if number of points falls to zero player has lost
        #endregion

        #region Contructors
        public Player(int size)
        {
            Size = size;
            ships = new bool[Size, Size];
            hits = new bool[Size, Size];
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Add ship to the board of the player
        /// </summary>
        /// <param name="ship"></param>
        /// <param name="point">
        /// First square used by the sship (top-most if vertical, left-most if horizontal) 
        /// </param>
        /// <returns></returns>
        public void AddShip(Ship ship, Point point)
        {
            CheckPoint(point);
            CheckShip(ship, point);
            CheckSquareOccupied(ship, point);

            if (ship.Alignment == Alignment.Vertical)
                for (var row = point.Row - 1; row < point.Row + ship.Length - 1; row++)
                    ships[row, point.Column - 1] = true;
            else if (ship.Alignment == Alignment.Horizontal)
                for (var col = point.Column - 1; col < point.Column + ship.Length - 1; col++)
                    ships[point.Row - 1, col] = true;

            hitpoints += ship.Length; // Every ship's length counts towards the player's points
        }

        public bool Attack(Point point)
        {
            CheckPoint(point);
            if (hits[point.Row - 1, point.Column - 1])
                throw new ArgumentException(string.Format(Resource.ExceptionSquareAlreadyHit, point.ToString()));

            hits[point.Row - 1, point.Column - 1] = true;
            if (!ships[point.Row - 1, point.Column - 1]) return false;
            hitpoints--; // Every successful first hit decrease the points of the player
            return true;
        }
        #endregion

        #region Private methods
        private void CheckPoint(Point point)
        {
            // Check if the point is on the board
            if (point.Row > Size || point.Column > Size)
                throw new ArgumentOutOfRangeException(
                    string.Format(Resource.ExceptionPointOutOfBoard, point.ToString(), Size));

        }

        private void CheckShip(Ship ship, Point point)
        {
            // Check if the Ship fits on the board
            if (ship.Alignment == Alignment.Vertical && (point.Row + ship.Length - 1) > Size
                || ship.Alignment == Alignment.Horizontal && (point.Column + ship.Length - 1) > Size)
                throw new ArgumentOutOfRangeException(Resource.ExceptionShipOutOfBoard); // Make the error message more useful
        }

        private void CheckSquareOccupied(Ship ship, Point point)
        {
            if (ship.Alignment == Alignment.Vertical)
                for (var row = point.Row - 1; row < point.Row + ship.Length - 1; row++)
                    if (ships[row, point.Column - 1])
                        throw new ArgumentOutOfRangeException(
                            string.Format(Resource.ExceptionSquareIsOccupied, point.ToString()));

            if (ship.Alignment == Alignment.Horizontal)
                for (var col = point.Column - 1; col < point.Column + ship.Length - 1; col++)
                    if (ships[point.Row - 1, col])
                        throw new ArgumentOutOfRangeException(
                            string.Format(Resource.ExceptionSquareIsOccupied, point.ToString()));
        }
        #endregion
    }
}
