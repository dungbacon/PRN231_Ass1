using System.ComponentModel.DataAnnotations;

namespace DataAccess.DTO
{
    public class PublisherDTO
    {
        public int PubId { get; set; }
        [Required]
        public string PubName { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string State { get; set; }
        [Required]
        public string Country { get; set; }
    }
}
