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
            var userThree = new GameAccount("Lomachenko"); 
            var userOneVsUserThree = new Game(userOne, userThree, 10);
            userOneVsUserThree.PlayGame();
            userOneVsUserThree.PlayGame();
            Console.WriteLine(userOne.GetStats());
            Console.WriteLine(userThree.GetStats());
        }
    }
}