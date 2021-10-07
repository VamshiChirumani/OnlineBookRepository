using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineBookStore.Models
{
    public partial class Order
    {
        [Key]
        [Column("OrderID")]
        public int OrderId { get; set; }
        [StringLength(50)]
        public string Category { get; set; }
        public int UserId { get; set; }
        public int Amount { get; set; }
    }
}
