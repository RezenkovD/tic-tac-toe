using System;
using System.Threading.Tasks;
using Npgsql;

namespace GameAccount.DataBase
{
    public class DataBase
    {
        protected static string NameDataBase = Environment.GetEnvironmentVariable("NameDataBase");
        protected static string PasswordDataBase = Environment.GetEnvironmentVariable("PasswordDataBase");
        protected static string UsernameDB = Environment.GetEnvironmentVariable("UsernameDB");
        private static string connectionString = $"Host=localhost;Username={UsernameDB};Password={PasswordDataBase};Database={NameDataBase}";
        private NpgsqlDataSource dataSource = NpgsqlDataSource.Create(connectionString); 
        public ValueTask<NpgsqlConnection> connection;
        private const string TABLE_NAME = "gamestats";
        public DataBase()
        {
            connection =  dataSource.OpenConnectionAsync();
        }

        public async Task CreateDataBase(string userName, int currentRating, string status, string opponentName, int rating, int gameIndex, string typeGame)
        {
            string commandText = $"INSERT INTO {TABLE_NAME} (UserName, CurrentRating, Status, OpponentName, Rating, GameIndex, TypeGame) VALUES (@uN, @cR, @s, @oN, @r, @gI, @tG)";
            using var cmd = new NpgsqlCommand(commandText, await connection);
            cmd.Parameters.AddWithValue("uN", userName);
            cmd.Parameters.AddWithValue("cR", currentRating);
            cmd.Parameters.AddWithValue("s", status);
            cmd.Parameters.AddWithValue("oN", opponentName);
            cmd.Parameters.AddWithValue("r", rating);
            cmd.Parameters.AddWithValue("gI", gameIndex);
            cmd.Parameters.AddWithValue("tG", typeGame);
            await cmd.ExecuteNonQueryAsync();
        }
    }
}