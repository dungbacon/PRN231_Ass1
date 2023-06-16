using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject.Models
{
    public class Book
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BookId { get; set; }
        [Required]
        public string Title{ get; set; }
        [Required]
        public string Type { get; set; }
        public int PubId { get; set; }
        public decimal Price { get; set; }
        public decimal Advance{ get; set; }
        public double Royalty { get; set; }
        public decimal YTDSales { get; set; }
        public string Notes { get; set; }
        public DateTime PublishedDate{ get; set; }

        public virtual List<BookAuthor>? BookAuthors { get; set; }

        public virtual Publisher? Publisher { get; set; }
    }
}
