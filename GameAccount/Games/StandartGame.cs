using System;

namespace GameAccount
{
    public class StandartGame: BaseGame
    {

        public int RandomChoice { get; set; }
        public StandartGame(BaseGameAccount userOne, BaseGameAccount userTwo, int rating) : base(userOne, userTwo, rating)
        {
            if (rating <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(rating), "The rating for which they are playing cannot be negative");
            }
        }

        public override void PlayGame()
        {
            var rnd = new Random();
            RandomChoice = rnd.Next(0, 101);
            if (RandomChoice <= 50)
            {
                UserOne.WinGame(UserTwo.UserName, this);
                UserTwo.LoseGame(UserOne.UserName, this);
            }
            else
            {
                UserTwo.WinGame(UserOne.UserName, this);
                UserOne.LoseGame(UserTwo.UserName, this);
            }
        }
    }
}