using BusinessObject.Models;

namespace DataAccess.DTO
{
    public class AuthorViewModel
    {
        public Author Author { get; set; } = null;

        public List<Author>? Authors { get; set; }
    }
}
