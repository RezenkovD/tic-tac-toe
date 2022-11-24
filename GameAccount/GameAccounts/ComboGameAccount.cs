using System.Threading.Tasks;
using Npgsql;

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

            var connectionString = $"Host=localhost;Username={UsernameDB};Password={PasswordDataBase};Database={NameDataBase}";
            await using var dataSource = NpgsqlDataSource.Create(connectionString); 
            await using var connection = await dataSource.OpenConnectionAsync(); 
            const string TABLE_NAME = "gamestats";
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
                
                string commandText = $"INSERT INTO {TABLE_NAME} (UserName, CurrentRating, Status, OpponentName, Rating, GameIndex, TypeGame) VALUES (@uN, @cR, @s, @oN, @r, @gI, @tG)";
                using var cmd = new NpgsqlCommand(commandText, connection);
                cmd.Parameters.AddWithValue("uN", UserName);
                cmd.Parameters.AddWithValue("cR", currentRating);
                cmd.Parameters.AddWithValue("s", item.Status);
                cmd.Parameters.AddWithValue("oN", item.OpponentName);
                cmd.Parameters.AddWithValue("r", item.Rating);
                cmd.Parameters.AddWithValue("gI", gameIndex);
                cmd.Parameters.AddWithValue("tG", item.TypeGame);
                await cmd.ExecuteNonQueryAsync();
            }
        }
    }
}