using System;

namespace GameAccount
{
    public class TraineGame: BaseGame
    {
        public int RandomChoice { get; set; }
        
        public TraineGame(BaseGameAccount userOne, BaseGameAccount userTwo) : base(userOne, userTwo)
        {
        }

        public override void PlayGame()
        {
            var rnd = new Random();
            RandomChoice = rnd.Next(0, 101);
            if (RandomChoice <= 50)
            {
                UserOne.WinGame(UserTwo.UserName, 0);
                UserTwo.LoseGame(UserOne.UserName, 0);
            }
            else
            {
                UserTwo.WinGame(UserOne.UserName, 0);
                UserOne.LoseGame(UserTwo.UserName, 0);
            }
        }
    }
}