using Consultorio.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Consultorio.Data.Mappings
{
    public class ConsultaMapping : IEntityTypeConfiguration<Consulta>
    {
        public void Configure(EntityTypeBuilder<Consulta> builder)
        {
            builder.ToTable("Consultas");
            builder.HasKey(x => x.Id);
            builder.Property(c => c.Status).HasColumnName("status");
            builder.Property(c => c.Preco).HasPrecision(10, 2).HasColumnName("preco");
            builder.Property(c => c.DataHorario).HasColumnName("horario");

            builder.Property(x => x.pacienteId).HasColumnName("id_paciente").IsRequired();
            builder.HasOne(x => x.Paciente).WithMany(x => x.Consultas).HasForeignKey(x => x.pacienteId);

        }
    }
}
