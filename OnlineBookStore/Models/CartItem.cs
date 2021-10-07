using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineBookStore.Models
{
    public partial class CartItem
    {
        [Key]
        [Column("ItemId")]
        public int ItemId { get; set; }
        [Column("userID")]
        public int userId { get; set; }
        [Column("BookId")]
        public int BookId { get; set; }
    }
}
