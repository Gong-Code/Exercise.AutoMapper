using AutoMapper;
using Exercise.AutoMapper.Dtos;
using Exercise.AutoMapper.Models;

namespace Exercise.AutoMapper.AutoMapper.Profiles
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<SuperHero, GetSuperHeros>();
            CreateMap<AddSuperHero, SuperHero>();
            CreateMap<UpdateSuperHeroes, SuperHero>();

        }
    }
}
