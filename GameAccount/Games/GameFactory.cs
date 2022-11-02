namespace GameAccount
{
    public class GameFactory
    {
        public static BaseGame GetStandartGame(BaseGameAccount userOne, BaseGameAccount userTwo, int rating)
        {
            return new StandartGame(userOne, userTwo, rating);
        }
        
        public static BaseGame GetTrainetGame(BaseGameAccount userOne, BaseGameAccount userTwo)
        {
            return new TraineGame(userOne, userTwo);
        }
    }
}