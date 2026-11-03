using System;
using System.IO;
using CatAndMouseGame;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Введите номер теста (1, 2, 3 или 4): ");
        string? choice = Console.ReadLine()?.Trim();

        if (choice != "1" && choice != "2" && choice != "3" && choice != "4")
        {
            Console.WriteLine("\nОшибка: Введён неверный номер теста! Допустимые значения: 1, 2, 3 или 4.");
            return;
        }

        Game.InputFile = $"{choice}.ChaseData.txt";
        Game.OutFile = $"{choice}.PursuitLog.txt";

        Game game = new Game();
        game.Run();

        if (File.Exists(Game.OutFile))
        {
            Console.WriteLine();
            Console.WriteLine(File.ReadAllText(Game.OutFile));
        }

        Console.WriteLine($"Результаты сохранены в {Game.OutFile}");
    }
}
