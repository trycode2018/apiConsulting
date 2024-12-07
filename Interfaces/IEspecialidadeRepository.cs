using Consultorio.Models;

namespace Consultorio.Interfaces
{
    public interface IEspecialidadeRepository
    {
        Task<IEnumerable<Especialidade>> GetAllAsync();
        Task<Especialidade> GetByIdAsync(int id);
        Task AddAsync(Especialidade especialidade);
        Task UpdateAsync(Especialidade especialidade);
        Task DeleteAsync(int id);
    }
}
