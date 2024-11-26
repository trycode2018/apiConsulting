using Consultorio.Models;

namespace Consultorio.Repositories.Interfaces.Pacientes
{
    public interface IPacienteRepository:IBaseRepository
    {
        Task<IEnumerable<Paciente>> GetAllPaciente();
        Task<Paciente> GetPacienteById(int id);
    }
}
