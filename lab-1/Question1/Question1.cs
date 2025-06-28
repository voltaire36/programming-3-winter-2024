using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignmment1.Question1
{
    public class Question1
    {
        public static void Run()
        {
            // Demonstrating Stack
            Console.WriteLine("Demonstrating Stack (LIFO):");
            Stack<MyGenericClass<string>> stack = new Stack<MyGenericClass<string>>();
            stack.Push(new MyGenericClass<string> { Data = "First" });
            stack.Push(new MyGenericClass<string> { Data = "Second" });
            stack.Push(new MyGenericClass<string> { Data = "Third" });

            Console.WriteLine("Adding 'First', 'Second', and 'Third' to the Stack.");
            Console.WriteLine("Stack (LIFO) Output:");
            while (stack.Count > 0)
            {
                Console.WriteLine(stack.Pop().Data);
            }

            // Demonstrating Queue
            Console.WriteLine("\nDemonstrating Queue (FIFO):");
            Queue<MyGenericClass<string>> queue = new Queue<MyGenericClass<string>>();
            queue.Enqueue(new MyGenericClass<string> { Data = "Alpha" });
            queue.Enqueue(new MyGenericClass<string> { Data = "Beta" });
            queue.Enqueue(new MyGenericClass<string> { Data = "Charlie" });

            Console.WriteLine("Adding 'Alpha', 'Beta', and 'Charlie' to the Queue.");
            Console.WriteLine("Queue (FIFO) Output:");
            while (queue.Count > 0)
            {
                Console.WriteLine(queue.Dequeue().Data);
            }

            // Demonstrating Type Constraint
            Console.WriteLine("\nDemonstrating Type Constraint:");
            Console.WriteLine("MyGenericClass<T> where T : class implies T must be a reference type.");

        }
    }
}
