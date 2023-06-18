using DataAccess.DTO;

namespace eBookStore.ViewModels
{
    public class BookViewModel
    {
        public BookDTO? Book { get; set; }

        public string? Message { get; set; }

        public List<BookDTO>? Books { get; set; }
    }
}
