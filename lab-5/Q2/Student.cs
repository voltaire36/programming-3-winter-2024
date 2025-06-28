using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.ML.Data;

namespace Q2
{
    public class Student
    {
        [LoadColumn(0)] public float STG;
        [LoadColumn(1)] public float SCG;
        [LoadColumn(2)] public float STR;
        [LoadColumn(3)] public float LPR;
        [LoadColumn(4)] public float PEG;
        [LoadColumn(5)] public string UNS; 
    }
}