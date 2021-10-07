using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineBookStore.Models
{
    public partial class Book
    {
        [Key]
        public int BookId { get; set; }
        [StringLength(50)]
        public string BookName { get; set; }
        public int Rating { get; set; }
        [StringLength(50)]
        public string Author { get; set; }
        public int Cost { get; set; }
    }
}
