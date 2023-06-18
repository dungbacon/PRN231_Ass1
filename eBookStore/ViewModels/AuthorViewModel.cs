using DataAccess.DTO;

namespace eBookStore.ViewModels
{
    public class AuthorViewModel
    {
        public AuthorDTO? Author { get; set; }

        public string? Message { get; set; }

        public List<AuthorDTO>? Authors { get; set; }
    }
}


