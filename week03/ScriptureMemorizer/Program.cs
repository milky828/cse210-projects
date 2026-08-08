using System;

class Program
{
    static void Main(string[] args)
    {
        /*
         * Creativity / Exceeding Requirements:
         *
         * I added a small scripture library with multiple scriptures.
         * The program randomly chooses a scripture each time it starts,
         * so the user can practice memorizing different scriptures.
         */

        Random random = new Random();

        Scripture[] scriptures =
        {
            new Scripture(
                new Reference("John", 3, 16),
                "For God so loved the world that he gave his only begotten Son that whosoever believeth in him should not perish but have everlasting life"
            ),

            new Scripture(
                new Reference("Proverbs", 3, 5, 6),
                "Trust in the Lord with all thine heart and lean not unto thine own understanding In all thy ways acknowledge him and he shall direct thy paths"
            ),

            new Scripture(
                new Reference("Philippians", 4, 13),
                "I can do all things through Christ which strengtheneth me"
            )
        };

        Scripture scripture = scriptures[random.Next(scriptures.Length)];

        while (!scripture.AllWordsHidden())
        {
            Console.Clear();

            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine();
            Console.WriteLine("Press Enter to hide words or type 'quit' to exit.");

            string input = Console.ReadLine();

            if (input.ToLower() == "quit")
            {
                break;
            }

            scripture.HideRandomWords(3);
        }

        Console.Clear();
        Console.WriteLine(scripture.GetDisplayText());
        Console.WriteLine();
        Console.WriteLine("Good job! You finished the scripture memorizer.");
    }
}