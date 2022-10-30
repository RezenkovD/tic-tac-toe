using System;
using System.Collections.Generic;

namespace GameAccount
{
    public class BaseGameAccount
        {
            public string UserName { get; }
            public int GamesCount { get; }

            public int CurrentRating
            {
                get
                {
                    int currentRating = 100;
                    foreach (var item in allRatingCalculations)
                    {
                        currentRating += item.Rating;
                    }
                    return currentRating;
                }
            }

            public void GameStart(int rating, string status, int gameIndex)
            {
                var startGame = new RatingCalculation(rating, status, "Game start", gameIndex);
                allRatingCalculations.Add(startGame);
            }

            public virtual void WinGame(string opponentName, int rating)
            {
                var winGame = new RatingCalculation(rating, "Game won", opponentName, 1);
                allRatingCalculations.Add(winGame);
            }

            public virtual void LoseGame(string opponentName, int rating)
            {
                if (CurrentRating - rating < 1)
                {
                    throw new InvalidOperationException("The rating cannot be less than 1");
                }
                var loseGame = new RatingCalculation(-rating, "Game lost", opponentName, 1);
                allRatingCalculations.Add(loseGame);
            }

            public string GetStats()
            {
                var report = new System.Text.StringBuilder();

                int currentRating = 100;
                int gameIndex = 0;
                report.AppendLine("UserName\tCurrentRating\tStatus\t\tOpponentName\tRating\tGameIndex");
                foreach (var item in allRatingCalculations)
                {
                    currentRating += item.Rating;
                    gameIndex += item.GameIndex;
                    report.AppendLine($"{UserName}\t{currentRating}\t\t{item.Status}\t{item.OpponentName}\t{item.Rating}\t{gameIndex}");
                }
                return report.ToString();
            }

            public BaseGameAccount(string userName)
            {
                UserName = userName;
                GamesCount = 0;
                GameStart(0, "Game start", 0);
            }

            protected List<RatingCalculation> allRatingCalculations = new List<RatingCalculation>();
        }
}