namespace GameAccount
{
    public class ComboGameAccount: BaseGameAccount
    {
        public ComboGameAccount(string userName) : base(userName)
        {
        }

        public override int CurrentRating
        {
            get
            {
                int currentRating = 100;
                int combo_won = 0;
                foreach (var item in allCalculations)
                {
                    if (item.Status == "Game won")
                    {
                        combo_won += 1;
                    }
                    if (combo_won == 2)
                    {
                        currentRating += 20;
                        combo_won = 0;
                    }
                    currentRating += item.Rating;
                }
                return currentRating;
            }
        }

        public override string GetStats()
        {
            var report = new System.Text.StringBuilder();
            int combo_won = 0;
            int currentRating = 100;
            int gameIndex = 0;
            report.AppendLine("UserName\tCurrentRating\tStatus\t\tOpponentName\tRating\tGameIndex\tTypeGame");
            foreach (var item in allCalculations)
            {
                if (item.Status == "Game won")
                {
                    combo_won += 1;
                }
                if (combo_won == 2)
                {
                    currentRating += 20;
                    combo_won = 0;
                }
                currentRating += item.Rating;
                gameIndex += item.GameIndex;
                report.AppendLine($"{UserName}\t{currentRating}\t\t{item.Status}\t{item.OpponentName}\t{item.Rating}\t{gameIndex}\t\t{item.TypeGame}");
            }
            return report.ToString();
        }
    }
}