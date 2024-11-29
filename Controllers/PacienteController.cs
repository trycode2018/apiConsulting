using Consultorio.DTOs.Pacientes;
using Consultorio.Models;
using Consultorio.Repositories.Interfaces.Pacientes;
using Consultorio.Response;
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

        [HttpPost]
        [Route("AddPaciente")]
        public async Task<ActionResult<Response<Paciente>>> AddPaciente(PacienteDTO paciente)
        {
            Response<Paciente> response = new Response<Paciente>();

            if (paciente == null)
            {
                response.Status = false;
                response.Message = "Passe as informações";
                
                return BadRequest(response);
            }

            var _paciente = new Paciente()
            {
                Nome=paciente.Nome,
                Email = paciente.Email,
                Cpf = paciente.Cpf,
                Telefone = paciente.Telefone,
            };

            await _repository.CreateAsync(_paciente);
            response.Data = _paciente;
            response.Message = "Dados adicionado com sucesso";
            response.Status = true;

            return Ok(response);
        }

        [HttpPut]
        [Route("UpdatePaciente")]
        public async Task<ActionResult<Response<Paciente>>> UpdatePaciente(PacienteAtualizarDTO pacienteAtualizar)
        {
            Response<Paciente> resposta = new Response<Paciente>();
            try
            {
                var paciente = await _repository.GetPacienteById(pacienteAtualizar.Id);
                if (paciente is null) 
                {
                    resposta.Message = "Paciente não encontrado!";
                    resposta.Status = false;
                    return BadRequest(resposta);
                }

                var novoPaciente = new Paciente() 
                {
                    Nome = pacienteAtualizar.Nome,
                    Email = pacienteAtualizar.Email,
                    Cpf = pacienteAtualizar.Cpf,
                    Telefone = pacienteAtualizar.Telefone
                };

                paciente.Data = novoPaciente;
                await _repository.UpdateAsync(paciente);

                resposta.Message = "Dado do Paciente atualizado";
                resposta.Status = true;
                resposta.Data = novoPaciente;

                return Ok(resposta);

            }catch(Exception err)
            {
                resposta.Message = err.Message;
                resposta.Status = false;
                return resposta;
            }
        }
    }
}
