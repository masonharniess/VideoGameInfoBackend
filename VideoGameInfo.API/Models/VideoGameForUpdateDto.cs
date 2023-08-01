using System.ComponentModel.DataAnnotations;

namespace VideoGameInfo.API.Models
{
    public class VideoGameForUpdateDto
    {
        [Required(ErrorMessage = "Please provide a Title value for any updated video game resource.")]
        [MaxLength(50)]
        public string Title { get; set; } = string.Empty;
        
        [MaxLength(200)]
        public string? Description { get; set; }

    }
}
