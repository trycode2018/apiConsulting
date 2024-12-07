using Consultorio.DTOs;
using Consultorio.Interfaces;
using Consultorio.Models;
using Consultorio.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Consultorio.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PacienteController : ControllerBase
    {
        private readonly IPacienteService _service;
        public PacienteController(IPacienteService service) => _service = service;

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var pacientes = await _service.GetAllAsync();
            return Ok(new ApiResponse(pacientes,"Pacientes encontrados com sucesso"));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var paciente = await _service.GetByIdAsync(id);
            return paciente != null
                ? Ok(new ApiResponse(paciente, "Paciente obtido com sucesso"))
                : NotFound(new ApiResponse(null, "Paciente não encontrado"));
        }

        [HttpPost]
        public async Task<IActionResult> Add(PacienteDTO pacienteDTO)
        {
            await _service.AddAsync(pacienteDTO);
            return CreatedAtAction(nameof(GetById), new { id = pacienteDTO.Nome }, new ApiResponse(null, "Paciente criado com sucesso"));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, PacienteDTO pacienteDTO)
        {
            await _service.UpdateAsync(id, pacienteDTO);
            return Ok(new ApiResponse(null, "Paciente atualizado com sucesso"));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id);
            return Ok(new ApiResponse(null, "Paciente excluído com sucesso"));
        }
    }
}
