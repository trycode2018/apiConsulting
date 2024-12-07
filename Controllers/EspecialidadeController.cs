using Consultorio.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Consultorio.Response;
using Consultorio.DTOs;

namespace Consultorio.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EspecialidadeController : ControllerBase
    {
        private readonly IEspecialidadeService _service;
        public EspecialidadeController(IEspecialidadeService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var especialidades = await _service.GetAllAsync();
            return Ok(new ApiResponse(especialidades,"Lista de especialidades"));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var especialidade = await _service.GetByIdAsync(id);
            return Ok(new ApiResponse(especialidade,"Especialidade encontrada"));
        }

        [HttpPost]
        public async Task<IActionResult> Add(EspecialidadeDTO especialidadeDTO)
        {
            await _service.AddAsync(especialidadeDTO);
            return CreatedAtAction(nameof(GetById),
                new { id = especialidadeDTO.Nome },
                new ApiResponse(await _service.GetAllAsync(),"Dados de especialidade adicionado"));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id,EspecialidadeDTO dto) 
        {
            await _service.UpdateAsync(id,dto);
            return Ok(new ApiResponse(await _service.GetByIdAsync(id), "Especialidade atualizada com exito"));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id);
            return Ok(new ApiResponse(null, "Especialidade excluida com exito"));
        }
    }
}
