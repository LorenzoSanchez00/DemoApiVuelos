using ApiVuelos.DTOs;
using ApiVuelos.Models;
using AutoMapper;

namespace ApiVuelos.Automappers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CrearVueloDto, Vuelo>();

            CreateMap<Vuelo, VueloDto>();
        }

    }
}
