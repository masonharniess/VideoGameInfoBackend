namespace VideoGameInfo.API.Models
{
    public class VideoGameDto
    {
        //public VideoGameDto(int id, string name) {
        //    Id = id;
        //    Name = name;
        //}

        //public VideoGameDto() { }

        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
    }
}
