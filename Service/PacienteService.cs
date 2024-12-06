using Consultorio.DTOs;
using Consultorio.Interfaces;
using Consultorio.Models;

namespace Consultorio.Service
{
    public class PacienteService : IPacienteService
    {
        private readonly IPacienteRepository _repository;
        public PacienteService(IPacienteRepository repository) => _repository = repository;
        public async Task AddAsync(PacienteDTO pacienteDTO)
        {
            var paciente = new Paciente
            {
                Nome = pacienteDTO.Nome,
                Email = pacienteDTO.Email,
                Cpf = pacienteDTO.Cpf,
                Telefone = pacienteDTO.Telefone
            };
            await _repository.AddAsync(paciente);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }

        public async Task<IEnumerable<PacienteDTO>> GetAllAsync()
        {
            var pacientes = await _repository.GetAllAsync();
            return pacientes.Select(p => new PacienteDTO
            {
                Nome = p.Nome,
                Email = p.Email,
                Cpf = p.Cpf,
                Telefone = p.Telefone
            });
        }

        public async Task<PacienteDTO> GetByIdAsync(int id)
        {
            var paciente = await _repository.GetByIdAsync(id);
            return new PacienteDTO
            {
                Nome = paciente.Nome,
                Email = paciente.Email,
                Cpf = paciente.Cpf,
                Telefone = paciente.Telefone
            };
        }

        public async Task UpdateAsync(int id, PacienteDTO pacienteDTO)
        {
            var paciente = await _repository.GetByIdAsync(id);
            if (paciente != null) 
            {
                paciente.Nome = pacienteDTO.Nome;
                paciente.Email = pacienteDTO.Email;
                paciente.Cpf = pacienteDTO.Cpf;
                paciente.Telefone = pacienteDTO.Telefone;
                await _repository.UpdateAsync(paciente);
            }
        }
    }
}
