using Consultorio.DTOs;
using Consultorio.Interfaces;
using Consultorio.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Consultorio.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfissionalController : ControllerBase
    {
        private readonly IProfissionalService _service;
        public ProfissionalController(IProfissionalService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() 
        {
            var profissionais = await _service.GetAllAsync();

            return Ok(new ApiResponse(profissionais, "Profissionais encontrados com exito"));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var profissional = await _service.GetByIdAsync(id);
            return profissional.Nome != null && profissional.Ativo!=-1 ?Ok(new ApiResponse(profissional, "Profissional encontrado com exito"))
                : NotFound(new ApiResponse(null, "Paciente não encontrado"));
        }

        [HttpPost]
        public async Task<IActionResult> Add(ProfissionalDTO profissionalDTO)
        {
            await _service.AddAsync(profissionalDTO);
            return CreatedAtAction(nameof(GetById),
                new {id = profissionalDTO.Nome},
                new ApiResponse(await _service.GetAllAsync(),"Profissional criado com exito"));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, ProfissionalDTO profissionalDTO)
        {
            await _service.UpdateAsync(id, profissionalDTO);
            var profissional = await _service.GetByIdAsync(id);
            return Ok(new ApiResponse(profissional, "Profissional Atualizado"));
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id);
            return Ok(new ApiResponse(null,"Profissional eliminado com exito"));
        }
    }
}
