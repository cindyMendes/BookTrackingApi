using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BookTrackingApi.Data
{
    public class BookCategory
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey(nameof(BookId))]
        public int BookId { get; set; }

        public Book Book { get; set; }

        [ForeignKey(nameof(CategoryId))]
        public int CategoryId { get; set; }

        public Category Category { get; set; }
    }
}
