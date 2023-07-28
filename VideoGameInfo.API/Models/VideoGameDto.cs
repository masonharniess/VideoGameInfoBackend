namespace VideoGameInfo.API.Models
{
    public class VideoGameDto
    {
        public VideoGameDto(int id, string name) {
            Id = id;
            Name = name;
        }

        public int Id { get; }
        public string Name { get; }
        public string? Description { get; }
    }
}
