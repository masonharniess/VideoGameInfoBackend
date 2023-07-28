using AutoMapper;

namespace VideoGameInfo.API.Profiles
{
    public class VideoGameProfile : Profile
    {
        public VideoGameProfile() {
            CreateMap<Entities.VideoGame, Models.VideoGameDto>();
            //CreateMap<Models.VideoGameForCreationDto, Entities.VideoGame>();
            //CreateMap<Models.VideoGameForUpdateDto, Entities.VideoGame>();
            //CreateMap<Entities.VideoGame, Models.VideoGameForUpdateDto>();
        }
    }
}
