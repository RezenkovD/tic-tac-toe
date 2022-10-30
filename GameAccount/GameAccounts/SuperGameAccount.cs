using System;

namespace GameAccount
{
    public class SuperGameAccount: BaseGameAccount
    {
        public SuperGameAccount(string userName) : base(userName)
        {
        }

        public override void WinGame(string opponentName, int rating)
        {
            var winGame = new RatingCalculation(2*rating, "Game won", opponentName, 1);
            allRatingCalculations.Add(winGame);
        }
        
        public override void LoseGame(string opponentName, int rating)
        {
            if (CurrentRating - rating < 1)
            {
                throw new InvalidOperationException("The rating cannot be less than 1");
            }
            var loseGame = new RatingCalculation(-rating/2, "Game lost", opponentName, 1);
            allRatingCalculations.Add(loseGame);
        }
    }
}