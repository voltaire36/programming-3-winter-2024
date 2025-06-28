﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary.Models
{
    public class Product
    {
        [Key]
        public short IdProduct { get; set; } // SMALLINT in SQL Server maps to short in C#
        public string ProductName { get; set; }
        public string Description { get; set; }
        [Column(TypeName = "decimal(6, 2)")]
        public decimal Price { get; set; }

        public virtual ICollection<BasketItem> BasketItems { get; set; }
    }

}
