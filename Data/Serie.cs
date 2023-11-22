using System.ComponentModel.DataAnnotations;

namespace BookTrackingApi.Data
{
    public class Serie
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        public bool IsFinished { get; set; }
    }
}
