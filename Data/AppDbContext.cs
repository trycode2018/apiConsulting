using Consultorio.Models;
using Microsoft.EntityFrameworkCore;

namespace Consultorio.Data
{
    public class AppDbContext : DbContext
    {

        public DbSet<Consulta> Consulta { get; set; }
        public DbSet<Paciente> Paciente { get; set; }
        public DbSet<Especialidade> Especialidade { get; set; }
        public DbSet<Profissional> Profissional { get; set; }
        public AppDbContext(DbContextOptions options) : base(options)
        {}
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        }
    }
}
