using Consultorio.Data;
using Consultorio.Interfaces;
using Consultorio.Models;
using Microsoft.EntityFrameworkCore;

namespace Consultorio.Repositories
{
    public class PacienteRepository : IPacienteRepository
    {
        private readonly AppDbContext _context;
        public PacienteRepository(AppDbContext context) => _context = context;
        public async Task AddAsync(Paciente paciente)
        {
            await _context.AddAsync(paciente);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var paciente = await GetByIdAsync(id);
            if (paciente != null) 
            {
                _context.Paciente.Remove(paciente);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Paciente>> GetAllAsync()
        {
            return await _context.Paciente.ToListAsync();
        }

        public async Task<Paciente> GetByIdAsync(int id)
        {
            var result = await _context.Paciente.FindAsync(id);
            if (result == null) return new Paciente { };

            return result;
        }

        public async Task UpdateAsync(Paciente paciente)
        {
            _context.Paciente.Update(paciente);
            await _context.SaveChangesAsync();
        }
    }
}
