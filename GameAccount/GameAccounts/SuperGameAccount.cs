using System;

namespace GameAccount
{
    public class SuperGameAccount: BaseGameAccount
    {
        public SuperGameAccount(string userName) : base(userName)
        {
        }

        public override void WinGame(string opponentName,BaseGame baseGame, string typeGame)
        {
            var winGame = new StatCalculation(2*baseGame.Rating, "Game won", opponentName, 1, typeGame);
            allCalculations.Add(winGame);
        }
        
        public override void LoseGame(string opponentName, BaseGame baseGame, string typeGame)
        {
            if (CurrentRating - baseGame.Rating < 1)
            {
                throw new InvalidOperationException("The rating cannot be less than 1");
            }
            var loseGame = new StatCalculation(-baseGame.Rating/2, "Game lost", opponentName, 1, typeGame);
            allCalculations.Add(loseGame);
        }
    }
}