using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace DataAccessLibrary.Models
{
    public class BasketItem
    {
        [Key]
        public int IdBasketItem { get; set; } // INT in SQL Server maps to int in C#
        public short IdProduct { get; set; } // SMALLINT in SQL Server maps to short in C#
        public byte Quantity { get; set; } // TINYINT in SQL Server maps to byte in C#
        public int IdBasket { get; set; }

        [ForeignKey("IdProduct")]
        public virtual Product Product { get; set; }
        [ForeignKey("IdBasket")]
        public virtual Basket Basket { get; set; }
    }
}

