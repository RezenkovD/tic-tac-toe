using System;

namespace GameAccount
{
    public class CustomException: Exception
    {
        public CustomException(string message) : base(message)
        {
        }
    }
}