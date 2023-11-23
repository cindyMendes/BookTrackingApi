namespace BookTrackingApi.DTOs.BookCategory
{
    public class UpdateBookCategoryDTO
    {
        public int Id { get; set; }

        public int BookId { get; set; }

        public int CategoryId { get; set; }
    }
}
