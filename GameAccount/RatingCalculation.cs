namespace GameAccount
{
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
}