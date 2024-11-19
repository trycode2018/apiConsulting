using Consultorio.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Consultorio.Data.Mappings
{
    public class EspecialidadeMapping : IEntityTypeConfiguration<Especialidade>
    {
        public void Configure(EntityTypeBuilder<Especialidade> builder)
        {
            builder.ToTable("especialidades");
            builder.HasKey(x => x.Id);
            builder.Property(e => e.Ativo).HasColumnName("ativo");
            builder.Property(e => e.Nome).HasColumnName("nome");
        }
    }
}
