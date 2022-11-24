using System;
using System.Threading.Tasks;

namespace GameAccount
{
    internal class Program
    {
        public static async Task Main(string[] args)
        {
            var Riezienkov = new BaseGameAccount("Riezienkov");
            var Nizhynets = new ComboGameAccount("Nizhynets");
            var Lomachenko = new SuperGameAccount("Lomachenko");
            var RiezienkovVsLomachenko = GameFactory.GetStandartGame(Riezienkov, Lomachenko, 20);
            var NizhynetsVsRiezienkov = GameFactory.GetTrainetGame(Nizhynets, Riezienkov);
            var LomachenkoVsNizhynets = GameFactory.GetStandartGame(Nizhynets, Lomachenko, 10);
            
            RiezienkovVsLomachenko.PlayGame();
            NizhynetsVsRiezienkov.PlayGame();
            LomachenkoVsNizhynets.PlayGame();
            
            var NizhynetsVsLomachenko = GameFactory.GetTicTacToe(Nizhynets, Lomachenko, 20);
            NizhynetsVsLomachenko.PlayGame();
            
            await Riezienkov.WriteStats();
            await Nizhynets.WriteStats();
            await Lomachenko.WriteStats();
            
            Console.Write("username\t");
            Console.Write("currentrating\t");
            Console.Write("status\t\t");
            Console.Write("opponentname\t");
            Console.Write("rating\t\t");
            Console.Write("gameindex\t");
            Console.Write("typegame\t"); 
            Console.WriteLine();
            
            var readDataBase = new DataBase.DataBase();
            await readDataBase.ReadDataBase();
        }
    }
}