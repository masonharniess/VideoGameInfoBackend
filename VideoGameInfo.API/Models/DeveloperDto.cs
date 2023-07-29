namespace VideoGameInfo.API.Models
{
    public class DeveloperDto
    {
        //public DeveloperDto(int id, string name) {
        //    Id = id;
        //    Name = name;
        //}

        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }

        public int NumberOfVideoGames
        {
            get { return VideoGames.Count; }
        }

        public ICollection<VideoGameDto> VideoGames { get; set; } = new List<VideoGameDto>();
    }
}
