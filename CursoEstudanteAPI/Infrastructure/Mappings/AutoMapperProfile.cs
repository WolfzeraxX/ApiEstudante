using AutoMapper;
using CursoEstudanteAPI.API.DTOs;
using CursoEstudanteAPI.Domain.Entities;



namespace CursoEstudanteAPI.Infrastructure.Mappings
{


    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Curso, CursoDto>().ReverseMap();
            CreateMap<Estudante, EstudanteDto>().ReverseMap();
            CreateMap<Avaliacao, AvaliacaoDto>().ReverseMap();
        }
    }

}
