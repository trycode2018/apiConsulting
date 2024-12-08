using Consultorio.Models;
using System.Text.Json.Serialization;

namespace Consultorio.DTOs
{
    public class ProfissionalDTO
    {
        public string? Nome { get; set; }
        public int Ativo { get; set; }
        //public List<Consulta> Consultas { get; set; }
    }
}
