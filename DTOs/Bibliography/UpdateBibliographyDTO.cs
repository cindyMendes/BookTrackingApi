namespace BookTrackingApi.DTOs.Bibliography
{
    public class UpdateBibliographyDTO
    {
        public int Id { get; set; }

        public int BookId { get; set; }

        public int AuthorId { get; set; }
    }
}
