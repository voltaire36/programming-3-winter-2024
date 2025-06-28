using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Assignmment1.Question2
{
    public class Question2
    {
        public static void Run() //"Consume" my extension method
        {
            StringBuilder sb = new StringBuilder("This is to test whether the extension method count can return a right answer or not"); // new object
            int wordCount = sb.CountWords();
            Console.WriteLine($"Number of words in StringBuilder: {wordCount}");
        }
    }
    public static class StringBuilderExtensions
    {
        public static int CountWords(this StringBuilder stringBuilder) //This is my extension method
        {
            if (stringBuilder == null || stringBuilder.Length == 0) return 0;

            int wordCount = 0;
            bool inWord = false;

            foreach (char c in stringBuilder.ToString())
            {
                if (char.IsWhiteSpace(c))
                {
                    inWord = false;
                }
                else if (!inWord)
                {
                    inWord = true;
                    wordCount++;
                }
            }

            return wordCount;
        }
    }
}
