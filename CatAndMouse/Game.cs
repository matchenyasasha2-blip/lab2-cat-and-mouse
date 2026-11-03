namespace CatAndMouseGame
{
    public enum GameState
    {
        Start,
        End
    }

    public class Game
    {
        public static string InputFile = "1.ChaseData.txt";
        public static string OutFile = "1.PursuitLog.txt";

        public int size;
        public Player cat;
        public Player mouse;
        public GameState state;

        public Game()
        {
            cat = new Player("Cat");
            mouse = new Player("Mouse");
            state = GameState.Start;
        }

        public void Run()
        {
        }
    }
}
