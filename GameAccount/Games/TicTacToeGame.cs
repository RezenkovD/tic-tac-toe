using System;

namespace GameAccount
{
    public class TicTacToe: BaseGame
    {
        public int ChoiceXUserOne { get; set; }
        public int ChoiceYUserOne { get; set; }
        public int ChoiceXUserTwo { get; set; }
        public int ChoiceYUserTwo { get; set; }

        public TicTacToe(BaseGameAccount userOne, BaseGameAccount userTwo, int rating) : base(userOne, userTwo, rating)
        {
        }

        public override void PlayGame()
        {
            string[,] TicTacToe = { { "-", "-", "-" }, { "-", "-", "-" }, { "-", "-", "-" } }; 
            GetArray(TicTacToe);
            for (int i = 0; i < TicTacToe.Length; i++)
            {
                if (i % 2 == 0)
                {
                    while (true)
                    {
                        try
                        {
                            Console.ForegroundColor = ConsoleColor.Blue; 
                            Console.Write("{0}, enter x: ", UserOne.UserName);
                            ChoiceXUserOne = Convert.ToInt32(Console.ReadLine());
                            Console.Write("{0}, enter y: ", UserOne.UserName);
                            ChoiceYUserOne = Convert.ToInt32(Console.ReadLine());
                            if (TicTacToe[ChoiceXUserOne, ChoiceYUserOne] == "-")
                            {
                                TicTacToe[ChoiceXUserOne, ChoiceYUserOne] = "X";
                                if (CheckTicTacToe(TicTacToe))
                                {
                                    GetArray(TicTacToe);
                                    Console.ForegroundColor = ConsoleColor.Green; 
                                    Console.WriteLine("Congratulations, {0}\n", UserOne.UserName);
                                    UserOne.WinGame(UserTwo.UserName, this, this.ToString());
                                    UserTwo.LoseGame(UserOne.UserName, this, this.ToString());
                                    return;
                                }
                            }
                            else
                            {
                                throw new CustomException("The move to this place has already been made");
                            }
                            break;
                        }
                        catch (CustomException)
                        {
                            Console.WriteLine("\tTry again\n\tThe move to this place has already been made"); 
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("\tEnter a number.\n\tThe game has been restarted!");
                        }
                        catch (IndexOutOfRangeException)
                        {
                            Console.WriteLine("\tUse only: 0, 1, 2.\n\tThe game has been restarted!");
                        }
                    }
                }
                else
                {
                    while (true)
                    {
                        try
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write("{0}, enter x: ", UserTwo.UserName);
                            ChoiceXUserTwo = Convert.ToInt32(Console.ReadLine());
                            Console.Write("{0}, enter y: ", UserTwo.UserName);
                            ChoiceYUserTwo = Convert.ToInt32(Console.ReadLine());
                            if (TicTacToe[ChoiceXUserTwo, ChoiceYUserTwo] == "-")
                            {
                                TicTacToe[ChoiceXUserTwo, ChoiceYUserTwo] = "O";
                                if (CheckTicTacToe(TicTacToe))
                                {
                                    GetArray(TicTacToe);
                                    Console.ForegroundColor = ConsoleColor.Green; 
                                    Console.WriteLine("Congratulations, {0}\n", UserTwo.UserName);
                                    UserTwo.WinGame(UserOne.UserName, this, this.ToString());
                                    UserOne.LoseGame(UserTwo.UserName, this, this.ToString());
                                    return;
                                }
                            }
                            else
                            {
                                throw new CustomException("The move to this place has already been made");
                            }
                            break;
                        }
                        catch (CustomException)
                        {
                            Console.WriteLine("\tTry again\n\tThe move to this place has already been made"); 
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("\tEnter a number.\n\tTry again!");
                        }
                        catch (IndexOutOfRangeException)
                        {
                            Console.WriteLine("\tUse only: 0, 1, 2.\n\tTry again!");
                        }
                    }
                }
                GetArray(TicTacToe);
            }
            Console.ForegroundColor = ConsoleColor.Gray; 
            Console.WriteLine("Draw Game!");
            UserOne.DrawGame(UserTwo.UserName, this, this.ToString());
            UserTwo.DrawGame(UserOne.UserName, this, this.ToString());
        }

        public static void GetArray(string[,] TicTacToe)
        { 
            Console.ForegroundColor = ConsoleColor.Black;
           for (int i = 0; i < TicTacToe.GetLength(0); i++)
           {
                for (int j = 0; j < TicTacToe.GetLength(1); j++)
                {
                    Console.Write(TicTacToe[i, j]+" ", Console.ForegroundColor);
                }
                Console.WriteLine();
           } 
        }

        public static bool CheckTicTacToe(string[,] TicTacToe)
        {
            if (TicTacToe[0, 0] == TicTacToe[0, 1] && TicTacToe[0, 1] == TicTacToe[0, 2])
            {
                switch (TicTacToe[0, 0])
                {
                    case "X":
                    case "O":
                        return true;
                }
            }
            if (TicTacToe[1, 0] == TicTacToe[1, 1] && TicTacToe[1, 1] == TicTacToe[1, 2])
            {
                switch (TicTacToe[1, 0])
                {
                    case "X":
                    case "O":
                        return true;
                }
            }
            if (TicTacToe[2, 0] == TicTacToe[2, 1] && TicTacToe[2, 1] == TicTacToe[2, 2])
            {
                switch (TicTacToe[2, 0])
                {
                    case "X":
                    case "O":
                        return true;
                }
            }
            if (TicTacToe[0, 0] == TicTacToe[1, 0] && TicTacToe[1, 0] == TicTacToe[2, 0])
            {
                switch (TicTacToe[0, 0])
                {
                    case "X":
                    case "O":
                        return true;
                }
            }
            if (TicTacToe[0, 1] == TicTacToe[1, 1] && TicTacToe[1, 1] == TicTacToe[2, 1])
            {
                switch (TicTacToe[0, 1])
                {
                    case "X":
                    case "O":
                        return true;
                }
            }
            if (TicTacToe[0, 2] == TicTacToe[1, 2] && TicTacToe[1, 2] == TicTacToe[2, 2])
            {
                switch (TicTacToe[0, 2])
                {
                    case "X":
                    case "O":
                        return true;
                }
            }
            if (TicTacToe[0, 0] == TicTacToe[1, 1] && TicTacToe[1, 1] == TicTacToe[2, 2])
            {
                switch (TicTacToe[0, 0])
                {
                    case "X":
                    case "O":
                        return true;
                }
            }
            if (TicTacToe[0, 2] == TicTacToe[1, 1] && TicTacToe[1, 1] == TicTacToe[2, 0])
            {
                switch (TicTacToe[0, 2])
                {
                    case "X":
                    case "O":
                        return true;
                }
            }
            return false;
        }
    }
}