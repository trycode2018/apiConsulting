using Consultorio.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Consultorio.Data.Mappings
{
    public class ProfissionalMapping : IEntityTypeConfiguration<Profissional>
    {
        public void Configure(EntityTypeBuilder<Profissional> builder)
        {
            builder.ToTable("profissional");
            builder.Property(p => p.Ativo).HasColumnName("ativo");
            builder.Property(p => p.Nome).HasColumnName("nome");
        }
    }
}
