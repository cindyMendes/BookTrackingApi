using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookTrackingApi.Data
{
    public class Bibliography
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey(nameof(BookId))]
        public int BookId { get; set; }

        public Book Book { get; set; }

        [ForeignKey(nameof(AuthorId))]
        public int AuthorId { get; set; }

        public Author Author { get; set; }
    }
}
