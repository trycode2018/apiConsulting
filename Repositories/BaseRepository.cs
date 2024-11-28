using Consultorio.Data;
using Consultorio.Repositories.Interfaces;
using Consultorio.Response;

namespace Consultorio.Repositories
{
    public class BaseRepository : IBaseRepository
    {
        private readonly AppDbContext _context;
        public BaseRepository(AppDbContext context) => _context = context;
        
        public async Task CreateAsync<T>(T entity)
        {
           // Response<T> response = new Response<T>();
            try
            {
                _context.Add(entity);
                await _context.SaveChangesAsync();

            }
            catch (Exception ex) 
            {
                return ;
            }
        }

        public async Task DeleteAsync<T>(int id)
        {
            _context.Remove(id);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync<T>(T entity)
        {
            _context.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
