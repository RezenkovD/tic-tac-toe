namespace GameAccount
{
    public abstract class BaseGame
    {
        protected readonly BaseGameAccount UserOne;
        protected readonly BaseGameAccount UserTwo;

        protected BaseGame(BaseGameAccount userOne, BaseGameAccount userTwo)
        {
            UserOne = userOne;
            UserTwo = userTwo;
        }

        public abstract void PlayGame();
    }
}