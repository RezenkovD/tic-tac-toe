using System;

namespace GameAccount
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var userOne = new GameAccount("Riezienkov");
            var userTwo = new GameAccount("Nizhenets");
            var userOneVsUserTwo = new Game(userOne, userTwo, 10);
            userOneVsUserTwo.PlayGame();
            userOneVsUserTwo.PlayGame();
            userOneVsUserTwo.PlayGame();
            userOneVsUserTwo.PlayGame();
            userOneVsUserTwo.PlayGame();
            Console.WriteLine(userOne.GetStats());
            Console.WriteLine(userTwo.GetStats());
        }
    }
}