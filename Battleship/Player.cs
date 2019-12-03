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
        /// Will check if the ship fits and the square are not occupied
        /// </summary>
        /// <param name="ship">
        /// Ship to add
        /// </param>
        /// <param name="point">
        /// First square used by the ship (top-most if vertical, left-most if horizontal) 
        /// </param>
        /// <returns></returns>
        public bool TryAddShip(Ship ship, Point point)
        {
            // Check if the Point is on the board
            if (point.Row > board.Size || point.Column > board.Size)
                return false;

            // Check if the Ship fits on the board
            if (ship.Orientation == Orientation.Vertical && (point.Row + ship.Length - 1) > board.Size
                || ship.Orientation == Orientation.Horizontal && (point.Column + ship.Length - 1) > board.Size)
                return false;

            // Add ship on the board if squared are not occupied
            var tmp = board.Clone();

            if (ship.Orientation == Orientation.Vertical)
                for (var row = point.Row; row < point.Row + ship.Length - 1; row++)
                    if (tmp.Matrix[row, point.Column].Occupied)
                        return false;
                    else
                        tmp.Matrix[row, point.Column].Occupied = true;
            else if (ship.Orientation == Orientation.Horizontal)
                for (var col = point.Column; col < point.Column + ship.Length - 1; col++)
                    if (tmp.Matrix[point.Row, col].Occupied)
                        return false;
                    else
                        tmp.Matrix[point.Row, col].Occupied = true;

            ships.Add(ship);
            board = tmp;
            return true;
        }

        public bool Attack(Point point)
        {
            // Check if the Point is on the board
            if (point.Row > board.Size || point.Column > board.Size)
                throw new ArgumentOutOfRangeException(
                    string.Format("Coordinates of the point {0} be inferior to the size of the board{3}", point.ToString()));

            attacks.Add(point);
            return true;
        }
        #endregion
    }
}
