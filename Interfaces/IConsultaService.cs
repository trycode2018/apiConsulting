using Consultorio.DTOs;

namespace Consultorio.Interfaces
{
    public interface IConsultaService
    {
        Task<IEnumerable<ConsultaDTO>> GetAllAsync();
        Task<ConsultaDTO> GetByIdAsync(int id);
        Task AddAsync(ConsultaDTO consultaDTO);
        Task DeleteAsync(int id);
        Task UpdateAsync(int id,ConsultaDTO consultaDTO);
    }
}
