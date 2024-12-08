using Consultorio.Data;
using Consultorio.Interfaces;
using Consultorio.Models;
using Microsoft.EntityFrameworkCore;

namespace Consultorio.Repositories
{
    public class ProfissionalRepository:IProfissionalRepository
    {
        private readonly AppDbContext _context;
        public ProfissionalRepository(AppDbContext context) => _context = context;

        public async Task AddAsync(Profissional profissional)
        {
            await _context.Profissional.AddAsync(profissional);
            await _context.SaveChangesAsync();
        }

        public async Task AddEspecialidade(ProfissionalEspecialidade especialidade)
        {
            await _context.ProfissionalEspecialidades.AddAsync(especialidade);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var profissional = await GetByIdAsync(id);
            if(profissional != null)
            {
                _context.Profissional.Remove(profissional);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Profissional>> GetAllAsync()
        {
            return await _context.Profissional.Include(x=>x.Consultas)
                .ToListAsync();
        }

        public async Task<Profissional> GetByIdAsync(int id)
        {
            var profissional = await  _context.Profissional.FindAsync(id);
            if(profissional != null)
                return profissional;

            return new Profissional { };
        }

        public async Task<ProfissionalEspecialidade> GetProfissionalEspecialidade(int profissionalId, int especialidadeId)
        {
            var model = await _context.ProfissionalEspecialidades
                .Where(x => x.ProfissionalId == profissionalId && x.EspecialidadeId == especialidadeId)
                .FirstOrDefaultAsync();
                return model;
            
        }

        public async Task UpdateAsync(Profissional profissional)
        {
            _context.Profissional.Update(profissional);
            await _context.SaveChangesAsync();
        }
    }
}
