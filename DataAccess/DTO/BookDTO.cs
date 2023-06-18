namespace DataAccess.DTO
{
    public class BookDTO
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public string Type { get; set; }
        public int PubId { get; set; }
        public decimal Price { get; set; }
        public decimal Advance { get; set; }
        public double Royalty { get; set; }
        public decimal YTDSales { get; set; }
        public string Notes { get; set; }
        public DateTime PublishedDate { get; set; }
    }
}
