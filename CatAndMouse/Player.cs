using System;

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

        public void Move(int steps, int boardSize)
        {
            if (state == State.NotInGame)
            {
                location = ((steps - 1) % boardSize + boardSize) % boardSize + 1;
                state = State.Playing;
            }
            else if (state == State.Playing && steps != 0)
            {
                distanceTraveled += Math.Abs(steps);
                location = ((location - 1 + steps) % boardSize + boardSize) % boardSize + 1;
            }
        }
    }
}
