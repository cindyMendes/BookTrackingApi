using System.ComponentModel.DataAnnotations;

namespace BookTrackingApi.Data
{
    public class Nationality
    {
        [Key]
        public int Id {  get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

    }
}
