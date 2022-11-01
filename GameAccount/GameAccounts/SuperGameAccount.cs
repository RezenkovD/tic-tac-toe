using System;

namespace GameAccount
{
    public class SuperGameAccount: BaseGameAccount
    {
        public SuperGameAccount(string userName) : base(userName)
        {
        }

        public override void WinGame(string opponentName,BaseGame baseGame)
        {
            var winGame = new RatingCalculation(2*baseGame.Rating, "Game won", opponentName, 1);
            allRatingCalculations.Add(winGame);
        }
        
        public override void LoseGame(string opponentName, BaseGame baseGame)
        {
            if (CurrentRating - baseGame.Rating < 1)
            {
                throw new InvalidOperationException("The rating cannot be less than 1");
            }
            var loseGame = new RatingCalculation(-baseGame.Rating/2, "Game lost", opponentName, 1);
            allRatingCalculations.Add(loseGame);
        }
    }
}