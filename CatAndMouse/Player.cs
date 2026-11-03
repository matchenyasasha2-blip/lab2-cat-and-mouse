namespace CatAndMouseGame
{
    public enum State
    {
        Winner,
        Looser,
        Playing,
        NotInGame
    }

    public class Player
    {
        public string name;
        public int location;
        public State state = State.NotInGame;
        public int distanceTraveled = 0;

        public Player(string name)
        {
            this.name = name;
            this.location = -1;
        }
    }
}
