using Consultorio.Models;
using Consultorio.Response;

namespace Consultorio.Repositories.Interfaces.Pacientes
{
    public interface IPacienteRepository:IBaseRepository
    {
        
        Task<Response<IEnumerable<Paciente>>> GetAllPaciente();
        Task<Response<Paciente>> GetPacienteById(int id);
    }
}
