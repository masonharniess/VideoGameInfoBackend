using AutoMapper;

namespace VideoGameInfo.API.Profiles
{
    public class DeveloperProfile : Profile
    {
        public DeveloperProfile() { 
            CreateMap<Entities.Developer, Models.DevelopersWithoutGamesDto>();
            CreateMap<Entities.Developer, Models.DeveloperDto>();
        }
    }
}
