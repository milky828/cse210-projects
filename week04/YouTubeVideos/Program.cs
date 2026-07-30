using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Video video1 = new Video("Best Football Skills", "Milky", 300);
        video1.AddComment(new Comment("John", "Amazing skills!"));
        video1.AddComment(new Comment("David", "Great video."));
        video1.AddComment(new Comment("Sarah", "I learned a lot."));

        Video video2 = new Video("C# Programming Basics", "Code Academy", 600);
        video2.AddComment(new Comment("Mike", "Very helpful."));
        video2.AddComment(new Comment("Anna", "Good explanation."));
        video2.AddComment(new Comment("Chris", "Thanks for sharing."));

        Video video3 = new Video("Travel Adventure", "Explorer", 450);
        video3.AddComment(new Comment("Emma", "Beautiful place."));
        video3.AddComment(new Comment("Alex", "I want to visit."));
        video3.AddComment(new Comment("Tom", "Awesome video."));

        List<Video> videos = new List<Video>
        {
            video1,
            video2,
            video3
        };

        foreach (Video video in videos)
        {
            Console.WriteLine("--------------------");
            Console.WriteLine($"Title: {video.Title}");
            Console.WriteLine($"Author: {video.Author}");
            Console.WriteLine($"Length: {video.Length} seconds");
            Console.WriteLine($"Comments: {video.GetNumberOfComments()}");

            foreach (Comment comment in video.Comments)
            {
                Console.WriteLine($"- {comment.Display()}");
            }

            Console.WriteLine();
        }
    }
}