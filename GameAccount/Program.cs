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
            public int CurrentRating { get; }

            public void StartGame(int rating, string status)
            {
                
            }

            public void WinGame(string opponentName, int rating)
            {
                
            }

            public void LoseGame(string opponentName, int rating)
            {
                
            }

            public void GetStats()
            {
                
            }

            public GameAccount(string userName)
            {
                UserName = userName;
                GamesCount = 0;
                CurrentRating = 0;
            }
        }
    }
}