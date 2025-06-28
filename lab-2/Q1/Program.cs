using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Random random = new Random();
        LinkedList<int> originalList = new LinkedList<int>();

        // Adding 10 random integers to the list
        for (int i = 0; i < 10; i++)
        {
            originalList.AddLast(random.Next(1, 100)); // Random int
        }

        // Displaying the list
        Console.WriteLine("Original List:");
        foreach (var item in originalList)
        {
            Console.Write(item + " ");
        }
        Console.WriteLine();

        // Creating a reversed copy of the first list
        LinkedList<int> reversedList = new LinkedList<int>();
        foreach (var item in originalList)
        {
            reversedList.AddFirst(item); // Adds each item to the start of the reversed list
        }

        // Displaying the reversed list
        Console.WriteLine("Reversed List:");
        foreach (var item in reversedList)
        {
            Console.Write(item + " ");
        }
        Console.WriteLine();
    }
}
