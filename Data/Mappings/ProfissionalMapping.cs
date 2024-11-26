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

            builder.HasMany(x => x.Especialidades)
                .WithMany(x => x.Profissionais)
                .UsingEntity<ProfissionalEspecialidade>(
                x => x.HasOne(p => p.Especialidade).WithMany().HasForeignKey(x => x.EspecialidadeId),
                x => x.HasOne(p => p.Profissional).WithMany().HasForeignKey(x => x.ProfissionalId),
                x =>
                { 
                    x.ToTable("tb_profissional_especialidade");
                    x.HasKey(p => new { p.EspecialidadeId, p.ProfissionalId });

                    x.Property(p => p.EspecialidadeId).HasColumnName("id_especialidade").IsRequired();
                    x.Property(p => p.ProfissionalId).HasColumnName("id_profissional").IsRequired();
                });
        }
    }
}
