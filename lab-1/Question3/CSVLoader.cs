using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignmment1.Question3
{


    public class CSVLoader
    {
        public SinglyLinkedList<Medalist> LoadMedalists(string filePath)
        {
            var medalistsList = new SinglyLinkedList<Medalist>();

            var lines = File.ReadAllLines(filePath);
            foreach (var line in lines.Skip(1)) // Assuming the first line contains headers
            {
                var tokens = line.Split(',');
                var medalist = new Medalist(tokens[0], tokens[1], tokens[2]);
                medalistsList.AddLast(medalist); // or medalistsList.AddFirst(medalist) to add at the beginning
            }

            return medalistsList;
        }
    }
}
