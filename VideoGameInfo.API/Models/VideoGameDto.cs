namespace VideoGameInfo.API.Models
{
    public class VideoGameDto
    {
        public VideoGameDto(int id, string name) {
            Id = id;
            Name = name;
        }

        public VideoGameDto() { }

        public int Id { get; }
        public string Name { get; } = string.Empty;
        public string? Description { get; init; }
    }
}
