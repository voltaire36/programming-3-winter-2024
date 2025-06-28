using DataAccessLibrary.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccessLibrary.Models
{
    public class Basket
    {
        [Key]
        public int IdBasket { get; set; }
        public int IdShopper { get; set; }
        public byte Quantity { get; set; }
        [Column(TypeName = "decimal(7, 2)")]
        public decimal SubTotal { get; set; }
        public DateTime OrderDate { get; set; }

        [ForeignKey("IdShopper")]
        public virtual Shopper Shopper { get; set; }
        public virtual ICollection<BasketItem> BasketItems { get; set; }

        [NotMapped]
        public string DisplayText => $"{Shopper?.Email} - Basket ID: {IdBasket}";
    }


}
