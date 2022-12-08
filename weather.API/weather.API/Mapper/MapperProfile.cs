using AutoMapper;
using weather.API.DataBase;
using weather.API.DTO;

namespace weather.API.Mapper;

public class MapperProfile : Profile
{
    public MapperProfile()
    {
        CreateMap<Measure, MeasureDto>().ReverseMap();
        CreateMap<HistMeasure, HistMeasureDto>().ReverseMap();
    }
}
