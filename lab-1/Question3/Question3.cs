using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignmment1.Question3
{

    class Question3
    {
        public static void Run()
        {
            var csvLoader = new CSVLoader();
            // Load medalists from the CSV file
            var medalists = csvLoader.LoadMedalists(@"C:\3 Centennial College\4th Semester\Programming 3\Assignment 1\Medals.csv");

            Console.WriteLine("All Medalists from CSV:");
            Console.WriteLine(medalists);

            // Create a new SinglyLinkedList
            var medalistsList = new SinglyLinkedList<Medalist>();

            // Adding medalists to demonstrate AddLast and AddFirst
            Console.WriteLine("Demonstrate AddLast and AddFirst");
            medalistsList.AddFirst(new Medalist("Michael Phelps", "USA", "Gold")); // This will be the last after adding more
            medalistsList.AddLast(new Medalist("Simone Biles", "USA", "Gold"));
            medalistsList.AddFirst(new Medalist("Usain Bolt", "Jamaica", "Gold")); // This will be the first

            Console.WriteLine("\nMedalists after adding 3 (Usain Bolt should be first, Simone Biles last):");
            Console.WriteLine(medalistsList);

            // Demonstrate First, Last, and GetSize
            Console.WriteLine("Demonstrate First, Last, and GetSize");
            Console.WriteLine($"First Medalist: {medalistsList.First()}");
            Console.WriteLine($"Last Medalist: {medalistsList.Last()}");
            Console.WriteLine($"Total number of Medalists: {medalistsList.GetSize()}");

            // Removing Medalists to demonstrate RemoveFirst
            Console.WriteLine("Demonstrate RemoveFirst");
            Console.WriteLine("\nRemoving first Medalist...");
            medalistsList.RemoveFirst();
            Console.WriteLine($"First Medalist after removal: {medalistsList.First()}");

            // Add a few more to remove
            Console.WriteLine("Add a few more to remove");
            medalistsList.AddLast(new Medalist("Katie Ledecky", "USA", "Gold"));
            medalistsList.AddLast(new Medalist("Allyson Felix", "USA", "Gold"));

            // Now remove two more to demonstrate repeated removal
            Console.WriteLine("\nRemoving two more Medalists (RemoveFirst)");
            medalistsList.RemoveFirst();
            medalistsList.RemoveFirst();
            Console.WriteLine($"First Medalist after two more removals: {medalistsList.First()}");

            // Final output to showcase the remaining list
            Console.WriteLine("\nFinal Medalists list after removals:");
            Console.WriteLine(medalistsList);

            // Check if the list is empty
            Console.WriteLine($"Is the Medalists list empty? {medalistsList.IsEmpty()}");

            // Clear the list by removing all elements
            while (!medalistsList.IsEmpty())
            {
                medalistsList.RemoveFirst();
            }

            // Final check to confirm the list is empty
            Console.WriteLine($"Is the Medalists list empty after clear? {medalistsList.IsEmpty()}");
        }
    }
}
