using System;
using System.Collections.Generic;
using System.Threading.Tasks;

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

            public virtual async Task WriteStats()
            {
                int currentRating = 100;
                int gameIndex = 0;
                foreach (var item in allCalculations)
                {
                    currentRating += item.Rating;
                    gameIndex += item.GameIndex;
                    var dataBase = new DataBase();
                    await dataBase.CreateDataBase(UserName, currentRating, item.Status, item.OpponentName, item.Rating,
                        gameIndex, item.TypeGame);
                }
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