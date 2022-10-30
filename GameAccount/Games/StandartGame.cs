using System;

namespace GameAccount
{
    public class StandartGame: BaseGame
    {

        public int RandomChoice { get; set; }
        public int Rating { get; }
        
        public StandartGame(BaseGameAccount userOne, BaseGameAccount userTwo, int rating) : base(userOne, userTwo)
        {
            if (rating <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(rating), "The rating for which they are playing cannot be negative");
            }
            Rating = rating; 
        }

        public override void PlayGame()
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