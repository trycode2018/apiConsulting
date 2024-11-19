using Consultorio.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Consultorio.Data.Mappings
{
    public class PacienteMapping : IEntityTypeConfiguration<Paciente>
    {
        public void Configure(EntityTypeBuilder<Paciente> builder)
        {
            builder.ToTable("Pacientes");
            builder.HasKey(x => x.Id);
            builder.Property(p => p.Nome).HasColumnName("nome");
            builder.Property(p => p.Telefone).HasMaxLength(12).HasColumnName("telefone");
            builder.Property(p => p.Email).HasMaxLength(50).HasColumnName("email");
            builder.Property(p => p.Cpf).HasColumnName("bi").HasMaxLength(13);

            //builder.Property(p => p.Consultas);
            //builder.HasMany(p => p.Consultas).WithOne(p => p.Paciente).HasForeignKey(p => p.pacienteId);
        }
    }
}
