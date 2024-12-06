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
    }
}
