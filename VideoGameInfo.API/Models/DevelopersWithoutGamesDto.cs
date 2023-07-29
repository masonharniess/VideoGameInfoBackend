namespace VideoGameInfo.API.Models
{
    public class DevelopersWithoutGamesDto
    {
        //public DevelopersWithoutGamesDto(int id, string name) {
        //    Id = id;
        //    Name = name;
        //}

        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
    }
}
