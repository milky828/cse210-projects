using System;

public class BreathingActivity : Activity
{
    public BreathingActivity()
        : base(
            "Breathing Activity",
            "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing."
        )
    {
    }

    public void Run()
    {
        StartActivity();

        DateTime endTime = DateTime.Now.AddSeconds(GetDuration());

        while (DateTime.Now < endTime)
        {
            Console.Write("Breathe in... ");

            int remaining = (int)(endTime - DateTime.Now).TotalSeconds;

            if (remaining <= 0)
            {
                break;
            }

            ShowCountdown(Math.Min(4, remaining));

            if (DateTime.Now >= endTime)
            {
                break;
            }

            Console.Write("Breathe out... ");

            remaining = (int)(endTime - DateTime.Now).TotalSeconds;

            if (remaining <= 0)
            {
                break;
            }

            ShowCountdown(Math.Min(4, remaining));

            Console.WriteLine();
        }

        EndActivity();
    }
}