using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VideoGameInfo.API.Entities
{
    public class Developer
    {
        public Developer(string name) { 
            Name = name;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [MaxLengthAttribute(200)]
        public string? Description { get; set; }

        public ICollection<Game> Games { get; set; } = new List<Game>();

    }
}
 