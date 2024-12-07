using Consultorio.DTOs;
using Consultorio.Interfaces;
using Consultorio.Models;

namespace Consultorio.Service
{
    public class ConsultaService:IConsultaService
    {
        private readonly IConsultaRepository _repository;
        public ConsultaService(IConsultaRepository repository)
        {
            _repository = repository;
        }

        public async Task AddAsync(ConsultaDTO consultaDTO)
        {
            var consulta = new Consulta
            {
                DataHorario = consultaDTO.DataHorario,
                Preco = consultaDTO.Preco,
                Status = consultaDTO.Status,
                pacienteId = consultaDTO.pacienteId,
                profissionalId = consultaDTO.profissionalId,
                especialidadeId = consultaDTO.especialidadeId
            };
            await _repository.AddAsync(consulta);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }

        public async Task<IEnumerable<ConsultaDTO>> GetAllAsync()
        {
            var consultas = await _repository.GetAllAsync();
            return consultas.Select(c => new ConsultaDTO
            {
                DataHorario = c.DataHorario,
                Preco = c.Preco,
                Status = c.Status,
                especialidadeId = c.especialidadeId,
                pacienteId = c.pacienteId,
                profissionalId = c.profissionalId
            });
        }

        public async Task<ConsultaDTO> GetByIdAsync(int id)
        {
            var consulta = await _repository.GetByIdAsync(id);
            return new ConsultaDTO
            {
                DataHorario = consulta.DataHorario,
                Preco = consulta.Preco,
                Status = consulta.Status,
                especialidadeId = consulta.especialidadeId,
                pacienteId = consulta.pacienteId,
                profissionalId = consulta.profissionalId
            };
        }

        public async Task UpdateAsync(int id, ConsultaDTO consultaDTO)
        {
            var consulta = await _repository.GetByIdAsync(id);
            if (consulta != null)
            {
                consulta.DataHorario = consultaDTO.DataHorario;
                consulta.Preco = consultaDTO.Preco;
                consulta.Status = consultaDTO.Status;
                consulta.pacienteId = consultaDTO.pacienteId;
                consulta.profissionalId = consultaDTO.profissionalId;
                consulta.especialidadeId = consultaDTO.especialidadeId;
                await _repository.UpdateAsync(consulta);
            }
        }
    }
}
