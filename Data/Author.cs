using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace BookTrackingApi.Data
{
    public class Author
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string FirstName { get; set; }

        [MaxLength(100)]
        public string MiddleName { get; set; }

        [Required]
        [MaxLength(100)]
        public string LastName { get; set; }

        [Required]
        public DateTime Birthday { get; set; }

        [ForeignKey(nameof(NationalityId))]
        public int NationalityId { get; set; }

        [JsonIgnore]
        public Nationality Nationality { get; set; }

    }
}
