using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ManageStockData
{
    public class Stock
    {
        public required string Symbol { get; set; }
        public DateOnly Date { get; set; }
        public Decimal Open { get; set; }
        public Decimal High { get; set; }
        public Decimal Low { get; set; }
        public Decimal Close { get; set; }

        public Stock() { }

        [SetsRequiredMembers]
        public Stock(string symbol, DateOnly d, Decimal open, Decimal high, Decimal low, Decimal close)
        { 
            Symbol = symbol; 
            Date = d;
            Open = open;
            High = high;
            Low = low;
            Close = close;
        }

        public override string ToString() //=> $"{Symbol,-20} {Date,-25} {Open,-20} {High,-20} {Low,-20} {Close,-20}";
        {
            return System.String.Format("{0,-30}  {1,-30}  {2,-20}  {3,20} {4,20} {5,20}", Symbol, Date, Open, High, Low, Close);
        }


    }
}
