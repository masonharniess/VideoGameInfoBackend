namespace VideoGameInfo.API.Profiles
{
    public class DeveloperProfile
    {
        public DeveloperProfile() { 
            CreateMap<Entities.Developer, Models.DevelopersWithoutGamesDto>();
            CreateMap<Entities.Developer, Models.DeveloperDto>();
        }
    }
}
