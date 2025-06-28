
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignmment1.Question1
{

    public class MyGenericClass<T> where T : class     // Type Constraint
    {
        public T Data { get; set; }
    }
}