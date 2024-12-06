using Consultorio.DTOs;

namespace Consultorio.Interfaces
{
    public interface IPacienteService
    {
        Task<IEnumerable<PacienteDTO>> GetAllAsync();
        Task<PacienteDTO> GetByIdAsync(int id);
        Task AddAsync(PacienteDTO paciente);
        Task UpdateAsync(int id, PacienteDTO paciente);
        Task DeleteAsync(int id);
    }
}
