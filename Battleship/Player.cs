using System;

namespace Battleship
{
    public class Player
    {
        #region Properties
        public readonly int Size;
        public bool HasLost => points == 0; // Player has lost when points had dropped to zero

        private bool[,] ships;              // False if empty, True if occupied
        private bool[,] hits;               // True if was hit
        private int points = 0;             // if number of points falls to zero player has lost
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
        /// First square used by the ship (top-most if vertical, left-most if horizontal) 
        /// </param>
        /// <returns></returns>
        public void AddShip(Ship ship, Point point)
        {
            CheckPoint(point);
            CheckShip(ship, point);
            CheckSquareOccupied(ship, point);

            if (ship.Orientation == Orientation.Vertical)
                for (var row = point.Row; row < point.Row + ship.Length - 1; row++)
                    ships[row, point.Column - 1] = true;
            else if (ship.Orientation == Orientation.Horizontal)
                for (var col = point.Column; col < point.Column + ship.Length - 1; col++)
                    ships[point.Row - 1, col] = true;

            points += ship.Length; // Every ship's length counts towards the player's points
        }

        public bool Attack(Point point)
        {
            CheckPoint(point);
            var occupied = ships[point.Row, point.Column];
            var hit = hits[point.Row, point.Column];
            if (occupied && !hit) points--; // Every successful first hit decrease the points of the player
            hits[point.Row, point.Column] = true;
            return occupied;
        }
        #endregion

        #region Private methods
        private void CheckPoint(Point point)
        {
            // Check if the point is on the board
            if (point.Row > Size || point.Column > Size)
                throw new ArgumentOutOfRangeException(
                    string.Format(Resource.ExceptionPointOutOfBoard, point.ToString()));

        }

        private void CheckShip(Ship ship, Point point)
        {
            // Check if the Ship fits on the board
            if (ship.Orientation == Orientation.Vertical && (point.Row + ship.Length - 1) > Size
                || ship.Orientation == Orientation.Horizontal && (point.Column + ship.Length - 1) > Size)
                throw new ArgumentOutOfRangeException(Resource.ExceptionShipOutOfBoard); // Make the error message more useful
        }

        private void CheckSquareOccupied(Ship ship, Point point)
        {
            if (ship.Orientation == Orientation.Vertical)
                for (var row = point.Row; row < point.Row + ship.Length - 1; row++)
                    if (ships[row, point.Column - 1])
                        throw new ArgumentOutOfRangeException(
                            string.Format(Resource.ExceptionSquareIsOccupied, point.ToString()));

            if (ship.Orientation == Orientation.Horizontal)
                for (var col = point.Column; col < point.Column + ship.Length - 1; col++)
                    if (ships[point.Row - 1, col])
                        throw new ArgumentOutOfRangeException(
                            string.Format(Resource.ExceptionSquareIsOccupied, point.ToString()));
        }
        #endregion
    }
}
