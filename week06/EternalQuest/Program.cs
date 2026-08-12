using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    // Creativity: Added a leveling system to make the Eternal Quest more engaging.
    // The user's level is based on their total points and is displayed in the menu.
    // This goes beyond the core requirements by adding an extra gamification feature.
    
    static string GetLevel(int score)
    {
        if (score >= 4000)
        {
            return "5 - Eternal Champion";
        }
        else if (score >= 2000)
        {
            return "4 - Faithful";
        }
        else if (score >= 1000)
        {
            return "3 - Dedicated";
        }
        else if (score >= 500)
        {
            return "2 - Apprentice";
        }
        else
        {
            return "1 - Beginner";
        }
    }

    static void Main(string[] args)
    {
        List<Goal> goals = new List<Goal>();
        int score = 0;

        while (true)
        {
            Console.Clear();

            Console.WriteLine($"You have {score} points.");
            Console.WriteLine($"Level: {GetLevel(score)}");
            Console.WriteLine();
            Console.WriteLine("Menu Options:");
            Console.WriteLine("1. Create New Goal");
            Console.WriteLine("2. List Goals");
            Console.WriteLine("3. Save Goals");
            Console.WriteLine("4. Load Goals");
            Console.WriteLine("5. Record Event");
            Console.WriteLine("6. Quit");
            Console.Write("Select a choice from the menu: ");

            string choice = Console.ReadLine();

            if (choice == "1")
            {
                CreateGoal(goals);
            }
            else if (choice == "2")
            {
                ListGoals(goals);
            }
            else if (choice == "3")
            {
                SaveGoals(goals, score);
            }
            else if (choice == "4")
            {
                LoadGoals(goals, ref score);
            }
            else if (choice == "5")
            {
                RecordEvent(goals, ref score);
            }
            else if (choice == "6")
            {
                break;
            }
        }
    }

    static void CreateGoal(List<Goal> goals)
    {
        Console.Clear();

        Console.WriteLine("The types of goals are:");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");
        Console.Write("Which type of goal would you like to create? ");

        string type = Console.ReadLine();

        Console.Write("What is the name of your goal? ");
        string name = Console.ReadLine();

        Console.Write("What is a short description of it? ");
        string description = Console.ReadLine();

        Console.Write("What is the amount of points associated with this goal? ");
        int points = int.Parse(Console.ReadLine());

        if (type == "1")
        {
            goals.Add(new SimpleGoal(name, description, points));
        }
        else if (type == "2")
        {
            goals.Add(new EternalGoal(name, description, points));
        }
        else if (type == "3")
        {
            Console.Write("How many times does this goal need to be completed? ");
            int targetAmount = int.Parse(Console.ReadLine());

            Console.Write("What is the bonus for completing the goal? ");
            int bonus = int.Parse(Console.ReadLine());

            goals.Add(new ChecklistGoal(
                name,
                description,
                points,
                targetAmount,
                bonus));
        }

        Console.WriteLine("Goal created successfully!");
        Console.WriteLine("Press Enter to continue.");
        Console.ReadLine();
    }

    static void ListGoals(List<Goal> goals)
    {
        Console.Clear();

        Console.WriteLine("The goals are:");

        if (goals.Count == 0)
        {
            Console.WriteLine("You don't have any goals yet.");
        }
        else
        {
            for (int i = 0; i < goals.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {goals[i].GetDetailsString()}");
            }
        }

        Console.WriteLine();
        Console.WriteLine("Press Enter to continue.");
        Console.ReadLine();
    }

    static void RecordEvent(List<Goal> goals, ref int score)
    {
        Console.Clear();

        if (goals.Count == 0)
        {
            Console.WriteLine("You don't have any goals to record.");
            Console.WriteLine("Press Enter to continue.");
            Console.ReadLine();
            return;
        }

        Console.WriteLine("The goals are:");

        for (int i = 0; i < goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {goals[i].GetDetailsString()}");
        }

        Console.Write("Which goal did you accomplish? ");
        int goalNumber = int.Parse(Console.ReadLine());

        if (goalNumber >= 1 && goalNumber <= goals.Count)
        {
            int pointsEarned = goals[goalNumber - 1].RecordEvent();

            if (pointsEarned > 0)
            {
                score += pointsEarned;

                Console.WriteLine();
                Console.WriteLine($"Congratulations! You have earned {pointsEarned} points!");
                Console.WriteLine($"You now have {score} points.");

                if (GetLevel(score) != GetLevel(score - pointsEarned))
                {
                    Console.WriteLine();
                    Console.WriteLine($"LEVEL UP! You are now {GetLevel(score)}!");
                }
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("That goal has already been completed.");
            }
        }
        else
        {
            Console.WriteLine("Invalid goal number.");
        }

        Console.WriteLine("Press Enter to continue.");
        Console.ReadLine();
    }

    static void SaveGoals(List<Goal> goals, int score)
    {
        Console.Clear();

        Console.Write("What is the filename for the goal file? ");
        string filename = Console.ReadLine();

        using (StreamWriter outputFile = new StreamWriter(filename))
        {
            outputFile.WriteLine(score);

            foreach (Goal goal in goals)
            {
                outputFile.WriteLine(goal.GetStringRepresentation());
            }
        }

        Console.WriteLine("Goals saved successfully!");
        Console.WriteLine("Press Enter to continue.");
        Console.ReadLine();
    }

    static void LoadGoals(List<Goal> goals, ref int score)
    {
        Console.Clear();

        Console.Write("What is the filename for the goal file? ");
        string filename = Console.ReadLine();

        if (!File.Exists(filename))
        {
            Console.WriteLine("File not found.");
            Console.WriteLine("Press Enter to continue.");
            Console.ReadLine();
            return;
        }

        string[] lines = File.ReadAllLines(filename);

        score = int.Parse(lines[0]);

        goals.Clear();

        for (int i = 1; i < lines.Length; i++)
        {
            string[] parts = lines[i].Split("|");

            string type = parts[0];
            string name = parts[1];
            string description = parts[2];
            int points = int.Parse(parts[3]);

            if (type == "SimpleGoal")
            {
                SimpleGoal goal = new SimpleGoal(name, description, points);

                if (bool.Parse(parts[4]))
                {
                    goal.RecordEvent();
                }

                goals.Add(goal);
            }
            else if (type == "EternalGoal")
            {
                goals.Add(new EternalGoal(name, description, points));
            }
            else if (type == "ChecklistGoal")
            {
                int targetAmount = int.Parse(parts[4]);
                int bonus = int.Parse(parts[5]);
                int amountCompleted = int.Parse(parts[6]);

                ChecklistGoal goal = new ChecklistGoal(
                    name,
                    description,
                    points,
                    targetAmount,
                    bonus);

                goal.SetAmountCompleted(amountCompleted);
                
                goals.Add(goal);
            }
        }

        Console.WriteLine("Goals loaded successfully!");
        Console.WriteLine("Press Enter to continue.");
        Console.ReadLine();
    }
}