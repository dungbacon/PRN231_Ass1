using DataAccess.DTO;

namespace eBookStore.ViewModels
{
    public class PublisherViewModel
    {
        public PublisherDTO? Publisher { get; set; }
        public string? Message { get; set; }
        public List<PublisherDTO>? Publishers { get; set; }
    }
}
