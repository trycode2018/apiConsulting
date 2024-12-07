using Consultorio.Data;
using Consultorio.Interfaces;
using Consultorio.Models;
using Microsoft.EntityFrameworkCore;

namespace Consultorio.Repositories
{
    public class ConsultaRepository:IConsultaRepository
    {
        private readonly AppDbContext _context;
        public ConsultaRepository(AppDbContext context) => _context = context;

        public async Task AddAsync(Consulta consulta)
        {
            await _context.Consulta.AddAsync(consulta);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var consulta = await GetByIdAsync(id);
            _context.Consulta.Remove(consulta);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Consulta>> GetAllAsync()
        {
            return await _context.Consulta.ToListAsync();
        }

        public async Task<Consulta> GetByIdAsync(int id)
        {
            var consulta = await _context.Consulta.FindAsync(id);
            if (consulta != null) return consulta;

            return new Consulta { };
        }

        public async Task UpdateAsync(Consulta consulta)
        {
            _context.Consulta.Update(consulta);
            await _context.SaveChangesAsync();
        }
    }
}
