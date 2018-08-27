using AutoMapper;
using ProjectCore.DTO;
using ProjectCore.Models;

namespace DAL.AutoMapper.Profiles
{
    public class PositionProfile : Profile
    {
        public PositionProfile()
        {
            CreateMap<Position, PositionDTO>();
            CreateMap<PositionDTO, Position>();
        }
    }
}
