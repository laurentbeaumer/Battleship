using System;
using System.Collections.Generic;

namespace Battleship
{
    public class Player
    {
        #region Properties
        private Board board = new Board();

        private List<Ship> ships = new List<Ship>();

        private List<Point> attacks = new List<Point>();
        #endregion

        #region Methods
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
                    board.Matrix[row, point.Column].Occupied = true;
            else if (ship.Orientation == Orientation.Horizontal)
                for (var col = point.Column; col < point.Column + ship.Length - 1; col++)
                    board.Matrix[point.Row, col].Occupied = true;

            ships.Add(ship);
        }

        public bool Attack(Point point)
        {
            CheckPoint(point);
            attacks.Add(point);
            board.Matrix[point.Row, point.Column].Hit = true;
            return board.Matrix[point.Row, point.Column].Occupied;
        }

        private void CheckPoint(Point point)
        {
            // Check if the point is on the board
            if (point.Row > board.Size || point.Column > board.Size)
                throw new ArgumentOutOfRangeException(
                    string.Format(Resource.ExceptionPointOutOfBoard, point.ToString()));

        }

        private void CheckShip(Ship ship, Point point)
        {
            // Check if the Ship fits on the board
            if (ship.Orientation == Orientation.Vertical && (point.Row + ship.Length - 1) > board.Size
                || ship.Orientation == Orientation.Horizontal && (point.Column + ship.Length - 1) > board.Size)
                throw new ArgumentOutOfRangeException(Resource.ExceptionShipOutOfBoard); // Make the error message more useful
        }

        private void CheckSquareOccupied(Ship ship, Point point)
        {
            if (ship.Orientation == Orientation.Vertical)
                for (var row = point.Row; row < point.Row + ship.Length - 1; row++)
                    if (board.Matrix[row, point.Column].Occupied)
                        throw new ArgumentOutOfRangeException(
                            string.Format(Resource.ExceptionSquareIsOccupied, point.ToString()));

            if (ship.Orientation == Orientation.Horizontal)
                for (var col = point.Column; col < point.Column + ship.Length - 1; col++)
                    if (board.Matrix[point.Row, col].Occupied)
                        throw new ArgumentOutOfRangeException(
                            string.Format(Resource.ExceptionSquareIsOccupied, point.ToString()));
        }
        #endregion
    }
}
