using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignmment1.Question3
{


    public class Medalist
    {
        public string Name { get; set; }
        public string Country { get; set; }
        public string Medal { get; set; }

        public Medalist(string name, string country, string medal)
        {
            Name = name;
            Country = country;
            Medal = medal;
        }

        public override string ToString()
        {
            return $"Name: {Name}, Country: {Country}, Medal: {Medal}";
        }
    }




}

