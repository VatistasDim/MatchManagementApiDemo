using AutoMapper;
using MatchManagementApiDemo.Models;
using MatchManagementApiDemo.Models.DTO;

namespace MatchManagementApiDemo.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Match, MatchDto>().ReverseMap();
            CreateMap<MatchOdds, MatchOddsDto>().ReverseMap();
        }
    }
}
