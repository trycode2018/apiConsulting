using Consultorio.DTOs;
using Consultorio.Interfaces;
using Consultorio.Models;

namespace Consultorio.Service
{
    public class EspecialidadeService:IEspecialidadeService
    {
        private readonly IEspecialidadeRepository _repository;
        public EspecialidadeService(IEspecialidadeRepository repository)
        {
            _repository = repository;
        }

        public async Task AddAsync(EspecialidadeDTO dto)
        {
            var especialidade = new Especialidade
            {
                Nome = dto.Nome,
                Ativo = dto.Ativo
            };
            await _repository.AddAsync(especialidade);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }

        public async Task<IEnumerable<EspecialidadeDTO>> GetAllAsync()
        {
            var especialidades = await _repository.GetAllAsync();
            return especialidades.Select(e => new EspecialidadeDTO
            {
                Nome = e.Nome,
                Ativo = e.Ativo
            });
        }

        public async Task<EspecialidadeDTO> GetByIdAsync(int id)
        {
            var especialidade = await _repository.GetByIdAsync(id);
            return new EspecialidadeDTO
            {
                Nome = especialidade.Nome,
                Ativo = especialidade.Ativo
            };
        }

        public async Task UpdateAsync(int id,EspecialidadeDTO dto)
        {
            var especialidade = await _repository.GetByIdAsync(id);
            if (especialidade != null)
            {
                especialidade.Nome = dto.Nome;
                especialidade.Ativo = dto.Ativo;
                await _repository.UpdateAsync(especialidade);
            }
           

        }
    }
}
