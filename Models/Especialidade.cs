namespace Consultorio.Models
{
    public class Especialidade
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public int Ativo { get; set; } 
        public List<Consulta> Consultas { get; set; }
        public List<Profissional> Profissionais { get; set; }
    }
}
