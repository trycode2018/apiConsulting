namespace Consultorio.Models
{
    public class Profissional
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public int Ativo { get; set; }
        public List<Consulta> Consultas { get; set; }
        public List<Especialidade> Especialidades { get; set; }
    }
}
