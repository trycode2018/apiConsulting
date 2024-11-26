namespace Consultorio.Models
{
    public class ProfissionalEspecialidade
    {
        public int ProfissionalId { get; set; }
        public Profissional Profissional { get; set; }
        public int EspecialidadeId { get; set; }
        public Especialidade Especialidade { get; set; }
    }
}
