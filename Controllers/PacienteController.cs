using Consultorio.Repositories.Interfaces.Pacientes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Consultorio.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PacienteController : ControllerBase
    {
        private readonly IPacienteRepository _repository;
        public PacienteController(IPacienteRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("GetAllPacientes")]
        public async Task<IActionResult> GetAllPacientes() 
        {
            var pacientes = await _repository.GetAllPaciente();

            return pacientes != null ? Ok(pacientes) :
                BadRequest("Pacientes não encontrados");
        }

        [HttpGet("GetPacienteById{id}")]
        public async Task<IActionResult> GetPacienteById(int id) 
        {
            var paciente = await _repository.GetPacienteById(id);
            return paciente != null ? Ok(paciente) :
                BadRequest("Paciente não encontrado");
        }
    }
}
