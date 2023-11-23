using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

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

        [Required]
        public DateTime PublishingDate { get; set; }

        public bool IsFavorite { get; set; }
        
        [Required]
        public bool IsRead { get; set; }

        public bool IsTBR { get; set; }

        [ForeignKey(nameof(SerieId))]
        public int SerieId { get; set; }

        [JsonIgnore]
        public Serie Serie { get; set; }

    }
}
