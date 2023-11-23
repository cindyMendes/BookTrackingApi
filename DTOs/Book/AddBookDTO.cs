using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BookTrackingApi.DTOs.Book
{
    public class AddBookDTO
    {
       public string Title { get; set; }

        public string Description { get; set; }

        public DateTime PublishingDate { get; set; }

        public bool IsFavorite { get; set; }

        public bool IsRead { get; set; }

        public bool IsTBR { get; set; }

        public int SerieId { get; set; }
    }
}
