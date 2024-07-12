using ApiVuelos.DTOs;
using ApiVuelos.Models;
using ApiVuelos.Services;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiVuelos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VuelosController : ControllerBase
    {
        private readonly IValidator<CrearVueloDto> _Addvalidator;
        private readonly IValidator<ModificarVueloDto> _UpdateValidator;
        private readonly ICommonService<VueloDto,CrearVueloDto,ModificarVueloDto> _vueloService;

        public VuelosController(IValidator<CrearVueloDto> validator,
                                IValidator<ModificarVueloDto> updateValidator,
                                [FromKeyedServices("FlyService")]ICommonService<VueloDto,CrearVueloDto,ModificarVueloDto> vueloService)
        {
            _Addvalidator = validator;
            _UpdateValidator = updateValidator;
            _vueloService = vueloService;
        }

        [HttpGet]
        public async Task<IEnumerable<VueloDto>> Get() =>
            await _vueloService.Get();

        [HttpGet("{id}")]
        public async Task<ActionResult<VueloDto>> GetById(int id)
        {
            var vueloDto = await _vueloService.GetById(id);

            return vueloDto == null ? NotFound() : Ok(vueloDto);
        }

        [HttpPost]
        public async Task<ActionResult<VueloDto>> Add(CrearVueloDto crearVueloDto)
        {
            var validationResult = await _Addvalidator.ValidateAsync(crearVueloDto);

            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }

            var vueloDto = await _vueloService.Add(crearVueloDto);

            return CreatedAtAction(nameof(GetById), new { id = vueloDto.IdVuelo }, vueloDto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<VueloDto>> Update(int id, ModificarVueloDto modVueloDto)
        {
            var validationResult = await _UpdateValidator.ValidateAsync(modVueloDto);

            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }

            var vueloDto = await _vueloService.Update(id, modVueloDto);

            
            return vueloDto == null ? NotFound() : Ok(vueloDto);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<VueloDto>> Delete(int id)
        {
            var vueloDto = await _vueloService.Delete(id);

            return vueloDto == null ? NotFound() : Ok(vueloDto);
        }

    }
}
