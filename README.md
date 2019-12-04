# Battleship
## Introduction

The game is played by two players, each one placing "battleships" on their 10 x 10 board.

The board of a player is hidden from the other player.

Once all the ships have been placed, the game can start.

Each Player attacks one position on each turn. They et a "hit" when an enemy ship is at that position, and a "miss" otherwise.

The first player who have "hit" all the ship positions of the other player wins the game.

## How to use the API

The code is provided as an API, and so will need to be contained in a service or an application.

You can add either "Battleship" project as a library or use the service.

The APi is made to be used in a do...while loop:

```C#
var service = new BattleshipService();
bool finished;

//  Add ships player 1
while(!finished) 
{
  // Get user's input
  // service.AddShip(new Ship() { ... }, new Point { ... } );
}
service.NextPlayer();

//  Add ships player 2
while(!finished) 
{
  // Get user's input
  // service.AddShip(new Ship() { ... }, new Point { ... } );
}
service.NextPlayer();

service.NextPlayer()
// Player 1 start attacking
do
{
// Get user's input
// service.Attack(new Point() { ... } )
}
while (service.NextPlayer()); // Will return false if the player has won.
```
