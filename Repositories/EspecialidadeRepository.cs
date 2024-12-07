using Consultorio.Data;
using Consultorio.Interfaces;
using Consultorio.Models;
using Microsoft.EntityFrameworkCore;

namespace Consultorio.Repositories
{
    public class EspecialidadeRepository:IEspecialidadeRepository
    {
        private readonly AppDbContext _context;
        public EspecialidadeRepository(AppDbContext context) => _context = context;

        public async Task AddAsync(Especialidade especialidade)
        {
            await _context.Especialidade.AddAsync(especialidade);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var especialidade = await GetByIdAsync(id);
            _context.Especialidade.Remove(especialidade);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Especialidade>> GetAllAsync()
        {
            return await _context.Especialidade.ToListAsync();
        }

        public async Task<Especialidade> GetByIdAsync(int id)
        {
            var especialidade = await _context.Especialidade.FindAsync(id);
            return especialidade!=null
                ?especialidade
                :new Especialidade { };
        }

        public async Task UpdateAsync(Especialidade especialidade)
        {
            _context.Especialidade.Update(especialidade);
            await _context.SaveChangesAsync();
        }
    }
}
