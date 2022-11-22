namespace GameAccount
{
    public class StatCalculation
    {
        public int Rating { get; }
        public string Status { get; }
        public string OpponentName { get; }
        public int GameIndex { get; }
        public string TypeGame { get; }

        public StatCalculation(int rating, string status, string opponentName, int gameIndex, string typeGame)
        {
            Rating = rating;
            Status = status;
            OpponentName = opponentName;
            GameIndex = gameIndex;
            TypeGame = typeGame;
        }
    }
}