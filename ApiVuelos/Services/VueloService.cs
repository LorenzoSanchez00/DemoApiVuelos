using ApiVuelos.DTOs;
using ApiVuelos.Models;
using ApiVuelos.Repository;
using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiVuelos.Services
{
    public class VueloService : ICommonService<VueloDto, CrearVueloDto, ModificarVueloDto>
    {
        private readonly IRepository<Vuelo> _repository;
        private readonly IMapper _mapper;

        public VueloService(IRepository<Vuelo> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<VueloDto>> Get()
        {
            var vuelos = await _repository.Get();

            return vuelos.Select(v => _mapper.Map<VueloDto>(v));
        }

        public async Task<VueloDto> GetById(int id)
        {
            var vuelo = await _repository.GetById(id);

            if (vuelo != null)
            {
                var vueloDto = _mapper.Map<VueloDto>(vuelo);
                return vueloDto;
            }
            return null;
        }
        public async Task<VueloDto> Add(CrearVueloDto crearVueloDto)
        {
            var vuelo = _mapper.Map<Vuelo>(crearVueloDto);
            await _repository.Add(vuelo);
            await _repository.Save();

            var vueloDto = _mapper.Map<VueloDto>(vuelo);

            return vueloDto;
        }

        public async Task<VueloDto> Update(int id, ModificarVueloDto modVueloDto)
        {
            var vuelo = await _repository.GetById(id);
            if (vuelo != null)
            {
                vuelo.IdAerolinea = modVueloDto.IdAerolinea;
                vuelo.Origen = modVueloDto.Origen;
                vuelo.Destino = modVueloDto.Destino;
                vuelo.FechaIda = modVueloDto.FechaIda;
                vuelo.FechaVuelta = modVueloDto.FechaVuelta;
                vuelo.Clase = modVueloDto.Clase;
                vuelo.Precio = modVueloDto.Precio;
                
                _repository.Update(vuelo);
                await _repository.Save();

                var vueloDto = _mapper.Map<VueloDto>(vuelo);

                return vueloDto;
            }
            return null;
        }

        public async Task<VueloDto> Delete(int id)
        {
            var vuelo = await _repository.GetById(id);

            if (vuelo != null)
            {
                var vueloDto = _mapper.Map<VueloDto>(vuelo);

                _repository.Delete(vuelo);
                await _repository.Save();

                return vueloDto;
            }
            return null;
        }

    }
}
