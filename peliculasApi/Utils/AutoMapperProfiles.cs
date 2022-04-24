using AutoMapper;
using peliculasApi.DTOs;
using peliculasApi.Entidades;

namespace peliculasApi.Utils
{
    public class AutoMapperProfiles:Profile
    {
        public AutoMapperProfiles()
        {           //entrada, salida
            CreateMap<Genero, GeneroDTO>().ReverseMap();
            CreateMap<CrearGeneroDTO, Genero>();
            CreateMap<GeneroEliminacionDTO, Genero>();
        }
    }
}
