using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject.Models
{
    public class BookAuthor
    {
        public int AuthorId { get; set; }
        public int BookId { get; set; }
        public string AuthorOrder { get; set; }
        public double RoyaltyPercentage { get; set; }
        public virtual Author? Author { get; set; }
        public virtual Book? Book { get; set; }
    }
}
