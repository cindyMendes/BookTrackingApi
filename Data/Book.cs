using System.ComponentModel.DataAnnotations;

namespace BookTrackingApi.Data
{
    public class Book
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(150)]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }
    }
}
