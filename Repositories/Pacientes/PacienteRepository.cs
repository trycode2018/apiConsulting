using Consultorio.Data;
using Consultorio.Models;
using Consultorio.Repositories.Interfaces.Pacientes;
using Microsoft.EntityFrameworkCore;

namespace Consultorio.Repositories.Pacientes
{
    public class PacienteRepository : BaseRepository, IPacienteRepository
    {
        private readonly AppDbContext _context;
        public PacienteRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Paciente>> GetAllPaciente()
        {
            var pacientes = await _context.Paciente.ToListAsync();
            return pacientes;
        }

        public async Task<Paciente> GetPacienteById(int id)
        {
            var paciente = await _context.Paciente.Where(x => x.Id == id).FirstOrDefaultAsync();
            return paciente;
        }
    }
}
