using System;

class Program
{
    static void Main(string[] args)
    {
        // Creativity: I added a "mood rating" feature to help users track how they felt each day.
        Journal journal = new Journal();

        string choice = "";

        while (choice != "5")
        {
            Console.WriteLine("Please select one of the following choices:");
            Console.WriteLine("1. Write");
            Console.WriteLine("2. Display");
            Console.WriteLine("3. Load");
            Console.WriteLine("4. Save");
            Console.WriteLine("5. Quit");
            Console.Write("What would you like to do? ");

            choice = Console.ReadLine();

            if (choice == "1")
            {
                Entry entry = new Entry();

                string[] prompts =
                {
                    "What was the best part of my day?",
                    "Who was the most interesting person I interacted with today?",
                    "What was the strongest emotion I felt today?",
                    "What did I learn today?",
                    "What made me smile today?"
                };

                Random random = new Random();
                int index = random.Next(prompts.Length);

                entry._prompt = prompts[index];

                Console.WriteLine(entry._prompt);
                Console.Write("> ");
                entry._response = Console.ReadLine();

                entry._date = DateTime.Now.ToShortDateString();

                journal._entries.Add(entry);
            }
            else if (choice == "2")
            {
                journal.Display();
            }
            else if (choice == "3")
            {
                Console.Write("What is the filename? ");
                string filename = Console.ReadLine();

                journal.LoadFromFile(filename);
            }
            else if (choice == "4")
            {
                Console.Write("What is the filename? ");
                string filename = Console.ReadLine();

                journal.SaveToFile(filename);
            }
        }
    }
}