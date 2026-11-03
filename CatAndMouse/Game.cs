using System;
using System.IO;

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
            File.WriteAllText(OutFile, "Cat and Mouse\n\n");

            if (!File.Exists(InputFile))
            {
                Console.WriteLine($"Ошибка: Файл {InputFile} не найден!");
                return;
            }

            string[] lines = File.ReadAllLines(InputFile);
            if (lines.Length == 0 || !int.TryParse(lines[0].Trim(), out int parsedSize) || parsedSize <= 0)
            {
                Console.WriteLine("Ошибка: неверный размер игрового поля!");
                return;
            }

            size = parsedSize;

            foreach (string line in lines)
            {
                if (state == GameState.End) break;

                string[] parts = line.Trim().Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
                if (parts.Length < 2 || !int.TryParse(parts[1], out int steps))
                    continue;

                char command = parts[0].ToUpper()[0];
                if (command == 'M')
                    mouse.Move(steps, size);
                else if (command == 'C')
                    cat.Move(steps, size);

                if (cat.state == State.Playing && mouse.state == State.Playing && cat.location == mouse.location)
                {
                    cat.state = State.Winner;
                    mouse.state = State.Looser;
                    state = GameState.End;
                }
            }

            if (cat.state == State.NotInGame || mouse.state == State.NotInGame)
            {
                Console.WriteLine("Ошибка: не заданы начальные позиции обоих игроков!");
                return;
            }

            string result = mouse.state == State.Looser
                ? $"Mouse caught at: {cat.location}\n"
                : "Mouse evaded Cat\n";

            File.AppendAllText(OutFile,
                $"Distance traveled: Mouse Cat\n {mouse.distanceTraveled,-14} {cat.distanceTraveled}\n\n{result}");
        }
    }
}
