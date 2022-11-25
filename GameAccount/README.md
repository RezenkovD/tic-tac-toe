# Task 1
## Create a GameAccount class.
### The class must have fields:
    • UserName – Name user.
    • CurrentRating – User rating.
    • GamesCount – Number of games played.
### Class has have functions:
    • WinGame with fields - a function that is called in case victory.
        • opponentName – opponent's name.
        • Rating - the rating for which the game was played.
    • LoseGame with fields - a function that is called in case of defeat.
        • opponentName – opponent's name.
        • Rating - the rating for which the game was played.
    • GetStats – a function that shows the history games (against whom, victory or defeat, what rating was played, game index).
### Create additional fields and functions as necessary.
### Additional conditions:
    • The rating cannot be less than 1.
    • The rating that is being played cannot be negative (in this case, an error must be thrown).
    • You need to create a separate class for the game it will store the necessary information.
    • 2 objects of the class must be created in the main player, simulate several games and display the statistics of each the player.

# Task 2
## Make several types of accounts with different methods of calculating points. 
    For example: a basic account, an account that withdraws half
    as much of points, in which additional points
    are accrued for a series of victories, etc.
## Make different types of games.Basic game must be abstract and there must be specific implementations.
    Example: standard game, training without rating, a game where only one player plays for the rating.
## Make a class which will contain functionality to return the game of any type, bringing it down to the basic game type.
## Modify player methods WinGame and LoseGame.
    So that instead of rating the object was coming
    base game in which there will be a method to
    determine what rating the game was on.

# Task 3
## Create a tic-tac-toe game.
## Create a connection to the database and implement recording of statistics in it.