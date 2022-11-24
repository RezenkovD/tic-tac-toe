using System.Threading.Tasks;

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

        public override async Task WriteStats()
        {
            int combo_won = 0;
            int currentRating = 100;
            int gameIndex = 0;
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
                var dataBase = new DataBase.DataBase();
                await dataBase.CreateDataBase(UserName, currentRating, item.Status, item.OpponentName, item.Rating,
                    gameIndex, item.TypeGame);
            }
        }
    }
}