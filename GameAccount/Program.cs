using System;

namespace GameAccount
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var userOne = new BaseGameAccount("Riezienkov");
            var userTwo = new BaseGameAccount("Nizhenets");
            var userOneVsUserTwo = new Game(userOne, userTwo, 10);
            userOneVsUserTwo.PlayGame();
            userOneVsUserTwo.PlayGame();
            userOneVsUserTwo.PlayGame();
            userOneVsUserTwo.PlayGame();
            userOneVsUserTwo.PlayGame();
            Console.WriteLine(userOne.GetStats());
            Console.WriteLine(userTwo.GetStats());
            var userThree = new BaseGameAccount("Lomachenko"); 
            var userOneVsUserThree = new Game(userOne, userThree, 10);
            userOneVsUserThree.PlayGame();
            userOneVsUserThree.PlayGame();
            Console.WriteLine(userOne.GetStats());
            Console.WriteLine(userThree.GetStats());
        }
    }
}