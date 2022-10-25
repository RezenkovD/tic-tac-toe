using System;

namespace GameAccount
{
    public class Game
    {
        public readonly GameAccount UserOne;
        public readonly GameAccount UserTwo;

        public int RandomChoice { get; set; }
        public int Rating { get; }

        public Game(GameAccount userOne, GameAccount userTwo, int rating)
        {
            if (rating <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(rating), "The rating for which they are playing cannot be negative");
            }
            UserOne = userOne;
            UserTwo = userTwo;
            Rating = rating;
        }

        public void PlayGame()
        {
            var rnd = new Random();
            RandomChoice = rnd.Next(0, 101);
            if (RandomChoice <= 50)
            {
                UserOne.WinGame(UserTwo.UserName, Rating);
                UserTwo.LoseGame(UserOne.UserName, Rating);
            }
            else
            {
                UserTwo.WinGame(UserOne.UserName, Rating);
                UserOne.LoseGame(UserTwo.UserName, Rating);
            }
        }
    }
}