﻿using System;
using System.Collections.Generic;

namespace GameAccount
{
    internal class Program
    {
        public static void Main(string[] args)
        {
        }

        public class GameAccount
        {
            public string UserName { get; }
            public int GamesCount { get; }

            public int CurrentRating
            {
                get
                {
                    int currentRating = 0;
                    foreach (var item in allRatingCalculations)
                    {
                        currentRating += item.Rating;
                    }
                    return currentRating;
                }
            }

            public void StartGame(int rating, string status)
            {
                var startGame = new RatingCalculation(rating, status, "null");
                allRatingCalculations.Add(startGame);
            }

            public void WinGame(string opponentName, int rating)
            {
                var winGame = new RatingCalculation(rating, "win game", opponentName);
                allRatingCalculations.Add(winGame);
            }

            public void LoseGame(string opponentName, int rating)
            {
                var loseGame = new RatingCalculation(rating, "win game", opponentName);
                allRatingCalculations.Add(loseGame); 
            }

            public void GetStats()
            {
                
            }

            public GameAccount(string userName)
            {
                UserName = userName;
                GamesCount = 0;
                StartGame(0, "start game");
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
    }
}