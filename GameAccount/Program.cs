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

            public void GameStart(int rating, string status)
            {
                var startGame = new RatingCalculation(rating, status, "Game start");
                allRatingCalculations.Add(startGame);
            }

            public void WinGame(string opponentName, int rating)
            {
                var winGame = new RatingCalculation(rating, "Game won", opponentName);
                allRatingCalculations.Add(winGame);
            }

            public void LoseGame(string opponentName, int rating)
            {
                if (CurrentRating - rating < 1)
                {
                    throw new InvalidOperationException("The rating cannot be less than 1");
                }
                var loseGame = new RatingCalculation(-rating, "Game lost", opponentName);
                allRatingCalculations.Add(loseGame);
            }

            public string GetStats()
            {
                var report = new System.Text.StringBuilder();

                int currentRating = 100;
                report.AppendLine("UserName\tCurrentRating\tStatus\t\tOpponentName\tRating");
                foreach (var item in allRatingCalculations)
                {
                    currentRating += item.Rating;
                    report.AppendLine($"{UserName}\t{currentRating}\t\t{item.Status}\t{item.OpponentName}\t{item.Rating}");
                }
                return report.ToString();
            }

            public GameAccount(string userName)
            {
                UserName = userName;
                GamesCount = 0;
                GameStart(0, "Game start");
            }

            private List<RatingCalculation> allRatingCalculations = new List<RatingCalculation>();

        }

        public class RatingCalculation
        {
            public int Rating { get; }
            public string Status { get; }
            public string OpponentName { get; }

            public RatingCalculation(int rating, string status, string opponentName)
            {
                Rating = rating;
                Status = status;
                OpponentName = opponentName;
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