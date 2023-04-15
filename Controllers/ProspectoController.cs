using Backend_ASP.NETcore.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Formats.Asn1;
using AutoMapper;
using Backend_ASP.NETcore.Models.DTO;
using Backend_ASP.NETcore.Models.Repository;

namespace Backend_ASP.NETcore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProspectoController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IProspectoRepository _prospectoRepository;

        public ProspectoController(IMapper mapper, IProspectoRepository prospectoRepository)
        {
            _mapper = mapper;
            _prospectoRepository = prospectoRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var listProspectos = await _prospectoRepository.GetListProspectos();

                var listProspectosDto = _mapper.Map<IEnumerable<ProspectoDTO>>(listProspectos);

                return Ok(listProspectosDto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var prospecto = await _prospectoRepository.GetProspecto(id);

                if (prospecto == null)
                {
                    return NotFound();
                }

                var prospectoDto = _mapper.Map<ProspectoDTO>(prospecto);

                return Ok(prospectoDto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var prospecto = await _prospectoRepository.GetProspecto(id);

                if (prospecto == null)
                {
                    return NoContent();
                }

                await _prospectoRepository.DeleteProspecto(prospecto);

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]

        public async Task<IActionResult> Post(ProspectoDTO prospectoDto)
        {
            try
            {
                var prospecto = _mapper.Map<Prospecto>(prospectoDto);

                prospecto.FechaCreacion = DateTime.Now;

                prospecto = await _prospectoRepository.AddProspecto(prospecto);

                var prospectoItemDto = _mapper.Map<ProspectoDTO>(prospecto);

                return CreatedAtAction("Get", new { id = prospectoItemDto.Id }, prospectoItemDto);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, ProspectoDTO prospectoDto)
        {
            try
            {
                var prospecto = _mapper.Map<Prospecto>(prospectoDto);

                if(id != prospecto.Id)
                {
                    return BadRequest();
                }

                var prospectoItem = await _prospectoRepository.GetProspecto(id);

                if(prospectoItem == null)
                {
                    return NotFound();
                }

                await _prospectoRepository.UpdateProspecto(prospecto);

                return NoContent();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}
