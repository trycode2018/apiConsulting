using Consultorio.DTOs;

namespace Consultorio.Interfaces
{
    public interface IProfissionalService
    {
        Task<IEnumerable<ProfissionalDTO>> GetAllAsync();
        Task<ProfissionalDTO> GetByIdAsync(int id);
        Task AddAsync(ProfissionalDTO profissionalDTO);
        Task DeleteAsync(int id);
        Task UpdateAsync(int id, ProfissionalDTO profissionalDTO);
    }
}
