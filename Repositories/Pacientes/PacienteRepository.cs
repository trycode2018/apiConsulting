using Consultorio.Data;
using Consultorio.Models;
using Consultorio.Repositories.Interfaces.Pacientes;
using Consultorio.Response;
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
        
        public async Task<Response<IEnumerable<Paciente>>> GetAllPaciente()
        {
            Response<IEnumerable<Paciente>> response = new Response<IEnumerable<Paciente>>();
            try
            {
                var pacientes = await _context.Paciente.ToListAsync();
                response.Data = pacientes;
                response.Message = "Lista de pacientes";
                response.Status = true;

                return response;
            }
            catch (Exception ex) 
            {
                response.Message = ex.Message;
                response.Status = false;
                return response;
            }
        }

        public async Task<Response<Paciente>> GetPacienteById(int id)
        {
            Response<Paciente> response = new Response<Paciente>();
            try
            {
                var paciente = await _context.Paciente.Where(x => x.Id == id).FirstOrDefaultAsync();
                response.Data = paciente;
                response.Message = "Paciente encontrado com sucesso!";
                response.Status = true;

                return response;
            }
            catch(Exception err)
            {
                response.Message = err.Message;
                response.Status = false;
                return response;
            }
        }
    }
}
