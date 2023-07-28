namespace VideoGameInfo.API.Models
{
    public class DeveloperDto
    {
        public DeveloperDto(int id, string name) {
            Id = id;
            Name = name;
        }

        public int Id { get; }
        public string Name { get; }
        public string? Description { get; init; }

        public int NumberOfVideoGames
        {
            get { return VideoGames.Count; }
        }

        public ICollection<VideoGameDto> VideoGames { get; set; } = new List<VideoGameDto>();
    }
}
