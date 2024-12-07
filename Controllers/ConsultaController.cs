using Consultorio.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Consultorio.Response;
using Consultorio.DTOs;

namespace Consultorio.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConsultaController : ControllerBase
    {
        private readonly IConsultaService _service;
        public ConsultaController(IConsultaService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var consultas = await _service.GetAllAsync();
            return Ok(new ApiResponse(consultas,"Todas as consultas marcadas"));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id) 
        {
            var consulta = await _service.GetByIdAsync(id);
            return Ok(new ApiResponse(consulta,"Consulta encontrada com exito"));
        }

        [HttpPost]
        public async Task<IActionResult> Add(ConsultaDTO consultaDTO)
        {
            await _service.AddAsync(consultaDTO);
            return Ok(new ApiResponse(consultaDTO,"Consulta adicionada com exito"));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, ConsultaDTO consultaDTO) 
        {
            await _service.UpdateAsync(id, consultaDTO);
            return Ok(new ApiResponse(_service.GetByIdAsync(id), "Consulta atualizada"));

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id) 
        {
            var consulta = await _service.GetByIdAsync(id);
            await _service.DeleteAsync(id);
            return Ok(new ApiResponse(consulta, "Consulta excluida com sucesso"));
        }

    }
}
