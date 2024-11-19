namespace Consultorio.Models
{
    public class Consulta
    {
        public int Id { get; set; }
        public string DataHorario { get; set; }
        public decimal Preco { get; set; }
        public int Status { get; set; }
        public int pacienteId { get; set; }
        public Paciente Paciente { get; set; }
    }
}
