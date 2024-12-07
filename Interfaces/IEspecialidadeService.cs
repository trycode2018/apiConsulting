using Consultorio.DTOs;

namespace Consultorio.Interfaces
{
    public interface IEspecialidadeService
    {
        Task<IEnumerable<EspecialidadeDTO>> GetAllAsync();
        Task<EspecialidadeDTO> GetByIdAsync(int id);
        Task AddAsync(EspecialidadeDTO dto);
        Task DeleteAsync(int id);
        Task UpdateAsync(int id,EspecialidadeDTO dto);
    }
}
