# Battleship
## Introduction

The game is played by two players, each one placing "battleships" on their 10 x 10 board.

The board of a player is hidden from the other player.

Once all the ships have been placed, the game can start.

The Player 1 attacks one position. The game says "hit" when an enemy ship has been hit, and "miss" otherwise.

Then Players 2 attacks one position, and so on.

The first player who have all his/her ships sunk (i.e. every position with a ship on it has been hit) has lost the game .

## How to use the API

The code is provided as an API, and so will need to be contained in a service or an application.

You can add either "Battleship" project as a library or use the service.

The API is made to be used in while loops:

```C#
var service = new BattleshipService();
bool finished, quit;

//  Add ships player 1
while(!quit && !finished) 
{
  // Get user's input
  // service.AddShip(new Ship() { ... }, new Point { ... } );
}
service.NextPlayer();

//  Add ships player 2
while(!quit && !finished) 
{
  // Get user's input
  // service.AddShip(new Ship() { ... }, new Point { ... } );
}
service.NextPlayer();

// Player 1 starts attacking
do
{
  // Get user's input
  // service.Attack(new Point() { ... } )
}
while (!quit && service.NextPlayer()); // Will return false if the player has won.
```
The code will throw an exception if the "attacked" position is outside the board or already hit, or by adding a ship where it doesn't fit, or on the top of an existing ship.

I advise to call the methods "AddShip" and "Attack" within a try/catch blocks, and show the error message to the user.
