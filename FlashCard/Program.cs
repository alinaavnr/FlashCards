using System;
using System.Collections.Generic;

class Program
{
    static void Clear()
    {
        Console.Write("\x1b[2J\x1b[H");
    }

    static Dictionary<string, string> words = new Dictionary<string, string>()
    {
        {"преимущество", "advantage"},
        {"окружающая среда", "environment"},
        {"путешествие", "journey"},
        {"настроение", "mood"},
        {"улучшать", "improve"},
        {"исследование", "research"},
        {"обсуждать", "discuss"},
        {"способность", "ability"},
        {"опыт", "experience"},
        {"образование", "education"}
    };

    static void Main()
    {
        Console.InputEncoding = System.Text.Encoding.UTF8;
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        while (true)
        {
            Clear();
            Console.WriteLine("=== ТРЕНАЖЁР АНГЛИЙСКИХ СЛОВ ===");
            Console.WriteLine("1. Изучение слов (тренировка)");
            Console.WriteLine("2. Добавить новое слово");
            Console.WriteLine("3. Показать список слов");
            Console.WriteLine("4. Выход");
            Console.Write("Выберите пункт: ");

            Console.Write(" ");
            Console.Write("\b");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Train();
                    break;

                case "2":
                    AddWord();
                    break;

                case "3":
                    ShowWords();
                    break;

                case "4":
                    return;

                default:
                    Console.WriteLine("Неверный ввод!");
                    Console.ReadKey();
                    break;
            }
        }
    }

    static void Train()
    {
        Clear();
        Console.WriteLine("=== ТРЕНИРОВКА ===\n");
        Console.WriteLine("Напишите перевод слова.");
        Console.WriteLine("Команды:");
        Console.WriteLine("  menu  - выйти в меню");
        Console.WriteLine("  exit  - завершить программу");
        Console.WriteLine("  skip  - пропустить слово\n");

        int score = 0;

        foreach (var pair in words)
        {
            Console.Write($"Переведите: {pair.Key}  (подсказка: {pair.Value[0]})\n> ");

            Console.Write(" ");
            Console.Write("\b");

            string answer = Console.ReadLine()?.Trim().ToLower();

            if (answer == "menu")
            {
                return;
            }
            if (answer == "exit")
            {
                Environment.Exit(0);
            }
            if (answer == "skip")
            {
                Console.WriteLine($"Пропущено. Правильно: {pair.Value}\n");
                continue;
            }

            if (answer == pair.Value.ToLower())
            {
                Console.WriteLine("✔ Правильно!\n");
                score++;
            }
            else
            {
                Console.WriteLine($"✘ Неверно. Правильно: {pair.Value}\n");
            }
        }

        Console.WriteLine($"Ваш результат: {score} из {words.Count}");
        Console.WriteLine("Нажмите любую клавишу...");
        Console.ReadKey();
    }
    static void AddWord()
    {
        Clear();
        Console.WriteLine("=== ДОБАВЛЕНИЕ СЛОВА ===");

        Console.Write("Введите слово на русском: ");
        Console.Write(" ");
        Console.Write("\b");

        string ru = Console.ReadLine()?.Trim().ToLower();

        Console.Write("Введите перевод на английском: ");
        Console.Write(" ");
        Console.Write("\b");

        string en = Console.ReadLine()?.Trim().ToLower();

        if (!string.IsNullOrWhiteSpace(ru) && !string.IsNullOrWhiteSpace(en))
        {
            if (!words.ContainsKey(ru))
            {
                words.Add(ru, en);
                Console.WriteLine("Слово успешно добавлено!\n");
            }
            else
            {
                Console.WriteLine("Такое слово уже есть!\n");
            }
        }
        else
        {
            Console.WriteLine("Ошибка! Пустой ввод.\n");
        }

        Console.WriteLine("Нажмите любую клавишу...");
        Console.ReadKey();
    }
    static void ShowWords()
    {
        Clear();
        Console.WriteLine("=== СПИСОК СЛОВ ===\n");

        foreach (var pair in words)
        {
            Console.WriteLine($"{pair.Key} → {pair.Value}");
        }

        Console.WriteLine("\nНажмите любую клавишу...");
        Console.ReadKey();
    }
}