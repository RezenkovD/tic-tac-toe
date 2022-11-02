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
                UserOne.WinGame(UserTwo.UserName, this, this.ToString());
                UserTwo.LoseGame(UserOne.UserName, this, this.ToString());
            }
            else
            {
                UserTwo.WinGame(UserOne.UserName, this, this.ToString());
                UserOne.LoseGame(UserTwo.UserName, this, this.ToString());
            }
        }
    }
}