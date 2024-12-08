using Consultorio.DTOs;
using Consultorio.Models;

namespace Consultorio.Interfaces
{
    public interface IProfissionalService
    {
        Task<IEnumerable<ProfissionalDTO>> GetAllAsync();
        Task<ProfissionalDTO> GetByIdAsync(int id);
        Task AddAsync(ProfissionalDTO profissionalDTO);
        Task DeleteAsync(int id);
        Task UpdateAsync(int id, ProfissionalDTO profissionalDTO);
        Task<ProfissionalEspecialidadeDTO> GetProfissionalEspecialidade(int profissionalId,int especialidadeId);
        Task AddEspecialidade(ProfissionalEspecialidadeDTO especialidadeDTO);
    }
}
