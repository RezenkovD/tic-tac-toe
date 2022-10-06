using System;
using System.Collections.Generic;

namespace GameAccount
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var userOne = new GameAccount("Riezienkov");
            var userTwo = new GameAccount("Nizhenets");
            var gameOne = new Game(userOne, userTwo, 10);
            gameOne.PlayGame();
            gameOne.PlayGame();
            gameOne.PlayGame();
            gameOne.PlayGame();
            gameOne.PlayGame();
            Console.WriteLine(userOne.GetStats());
            Console.WriteLine(userTwo.GetStats());
        }

        public class GameAccount
        {
            public string UserName { get; }
            public int GamesCount { get; }

            public int GameIndex
            {
                get
                {
                    int gameIndex = 0;
                    foreach (var item in allRatingCalculations)
                    {
                        gameIndex += item.GameIndex;
                    }

                    return gameIndex;
                }
            }

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

            public void WinGame(string opponentName, int rating)
            {
                var winGame = new RatingCalculation(rating, "Game won", opponentName, 1);
                allRatingCalculations.Add(winGame);
            }

            public void LoseGame(string opponentName, int rating)
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

            public GameAccount(string userName)
            {
                UserName = userName;
                GamesCount = 0;
                GameStart(0, "Game start", 0);
            }

            private List<RatingCalculation> allRatingCalculations = new List<RatingCalculation>();

        }

        public class RatingCalculation
        {
            public int Rating { get; }
            public string Status { get; }
            public string OpponentName { get; }
            public int GameIndex { get; }

            public RatingCalculation(int rating, string status, string opponentName, int gameIndex)
            {
                Rating = rating;
                Status = status;
                OpponentName = opponentName;
                GameIndex = gameIndex;
            }
        }

        public class Game
        {
            public readonly GameAccount UserOne;
            public readonly GameAccount UserTwo;
            public int Rating { get; }

            public Game(GameAccount userOne, GameAccount userTwo, int rating)
            {
                if (rating <= 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(rating), "The rating for which they are playing cannot be negative");
                }
                UserOne = userOne;
                UserTwo = userTwo;
                Rating = rating;
            }

            public void PlayGame()
            {
                var rnd = new Random();
                int randomChoice = rnd.Next(0, 101);
                if (randomChoice <= 50)
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
}