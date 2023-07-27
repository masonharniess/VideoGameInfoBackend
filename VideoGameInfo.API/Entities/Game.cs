using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VideoGameInfo.API.Entities
{
    public class Game
    {
        public Game(String title) {
            Title = title;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Title { get; set; }

        [MaxLength(200)]
        public string? Description { get; set; }

        [ForeignKey("DeveloperId")]
        public Developer? Developer { get; set; }
        public int DeveloperId { get; set; }

    }
}
