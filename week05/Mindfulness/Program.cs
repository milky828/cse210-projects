using System;
using System.Threading;

class Program
{
    static void Main(string[] args)
    {
        /*
         * Creativity / Exceeding Requirements:
         *
         * I added a session summary that keeps track of how many
         * times each mindfulness activity was completed.
         *
         * I also added random prompts and questions, countdowns,
         * and spinner animations to make the program more engaging.
         */

        int breathingCount = 0;
        int reflectionCount = 0;
        int listingCount = 0;

        bool running = true;

        while (running)
        {
            Console.Clear();

            Console.WriteLine("Mindfulness Program");
            Console.WriteLine();
            Console.WriteLine("Menu Options:");
            Console.WriteLine("  1. Start breathing activity");
            Console.WriteLine("  2. Start reflecting activity");
            Console.WriteLine("  3. Start listing activity");
            Console.WriteLine("  4. Quit");
            Console.WriteLine();

            Console.Write("Select a choice from the menu: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    BreathingActivity breathing = new BreathingActivity();
                    breathing.Run();
                    breathingCount++;
                    break;

                case "2":
                    ReflectionActivity reflection = new ReflectionActivity();
                    reflection.Run();
                    reflectionCount++;
                    break;

                case "3":
                    ListingActivity listing = new ListingActivity();
                    listing.Run();
                    listingCount++;
                    break;

                case "4":
                    Console.Clear();

                    int totalActivities =
                        breathingCount +
                        reflectionCount +
                        listingCount;

                    Console.WriteLine("Thank you for using the Mindfulness Program!");
                    Console.WriteLine();
                    Console.WriteLine("Session Summary:");
                    Console.WriteLine($"Breathing activities: {breathingCount}");
                    Console.WriteLine($"Reflection activities: {reflectionCount}");
                    Console.WriteLine($"Listing activities: {listingCount}");
                    Console.WriteLine($"Total activities: {totalActivities}");
                    Console.WriteLine();

                    running = false;
                    break;

                default:
                    Console.WriteLine();
                    Console.WriteLine("Invalid choice. Please select 1, 2, 3, or 4.");
                    Thread.Sleep(1500);
                    break;
            }
        }
    }
}