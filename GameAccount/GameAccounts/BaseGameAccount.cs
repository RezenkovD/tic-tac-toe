using System;
using System.Collections.Generic;

namespace GameAccount
{
    public class BaseGameAccount
        {
            public string UserName { get; }
            public int GamesCount { get; }

            public virtual int CurrentRating
            {
                get
                {
                    int currentRating = 100;
                    foreach (var item in allCalculations)
                    {
                        currentRating += item.Rating;
                    }
                    return currentRating;
                }
            }

            public void GameStart(int rating, string status, int gameIndex)
            {
                var startGame = new StatCalculation(rating, status, "Game start", gameIndex, "Start Game");
                allCalculations.Add(startGame);
            }
            public virtual void WinGame(string opponentName, BaseGame baseGame, string typeGame)
            {
                var winGame = new StatCalculation(baseGame.Rating, "Game won", opponentName, 1, typeGame);
                allCalculations.Add(winGame);
            }
            public virtual void DrawGame(string opponentName, BaseGame baseGame, string typeGame)
            {
                var drawGame = new StatCalculation(0, "Draw game", opponentName, 1, typeGame);
                allCalculations.Add(drawGame);
            }
            public virtual void LoseGame(string opponentName, BaseGame baseGame, string typeGame)
            {
                if (CurrentRating - baseGame.Rating < 1)
                {
                    throw new InvalidOperationException("The rating cannot be less than 1");
                }
                var loseGame = new StatCalculation(-baseGame.Rating, "Game lost", opponentName, 1, typeGame);
                allCalculations.Add(loseGame);
            }

            public virtual string GetStats()
            {
                var report = new System.Text.StringBuilder();

                int currentRating = 100;
                int gameIndex = 0;
                report.AppendLine("UserName\tCurrentRating\tStatus\t\tOpponentName\tRating\tGameIndex\tTypeGame");
                foreach (var item in allCalculations)
                {
                    currentRating += item.Rating;
                    gameIndex += item.GameIndex;
                    report.AppendLine($"{UserName}\t{currentRating}\t\t{item.Status}\t{item.OpponentName}\t{item.Rating}\t{gameIndex}\t\t{item.TypeGame}");
                }
                return report.ToString();
            }

            public BaseGameAccount(string userName)
            {
                UserName = userName;
                GamesCount = 0;
                GameStart(0, "Game start", 0);
            }

            protected List<StatCalculation> allCalculations = new List<StatCalculation>();
        }
}