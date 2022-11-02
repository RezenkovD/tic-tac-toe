using System;

namespace GameAccount
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var Riezienkov = new BaseGameAccount("Riezienkov");
            var Nizhynets = new SuperGameAccount("Nizhynets");
            var Lomachenko = new ComboGameAccount("Lomachenko");
            
            var RiezienkovVsLomachenko = new StandartGame(Riezienkov, Lomachenko, 20);
            var NizhynetsVsRiezienkov = new TraineGame(Nizhynets, Riezienkov);
            var LomachenkoVsNizhynets = new StandartGame(Nizhynets, Lomachenko, 10);
            
            RiezienkovVsLomachenko.PlayGame();
            RiezienkovVsLomachenko.PlayGame();
            RiezienkovVsLomachenko.PlayGame();
            RiezienkovVsLomachenko.PlayGame();
            NizhynetsVsRiezienkov.PlayGame();
            NizhynetsVsRiezienkov.PlayGame();
            LomachenkoVsNizhynets.PlayGame();
            LomachenkoVsNizhynets.PlayGame();
            LomachenkoVsNizhynets.PlayGame();
            LomachenkoVsNizhynets.PlayGame();

            Console.WriteLine(Riezienkov.GetStats());
            Console.WriteLine(Nizhynets.GetStats());
            Console.WriteLine(Lomachenko.GetStats());
            
        }
    }
}