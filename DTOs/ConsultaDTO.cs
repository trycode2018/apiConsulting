using Consultorio.Models;

namespace Consultorio.DTOs
{
    public class ConsultaDTO
    {
        public string DataHorario { get; set; }
        public decimal Preco { get; set; }
        public int Status { get; set; }
        public int pacienteId { get; set; }
        public int profissionalId { get; set; }
        public int especialidadeId { get; set; }
    }
}
