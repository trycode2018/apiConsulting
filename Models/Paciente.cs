using System.Text.Json.Serialization;

namespace Consultorio.Models
{
    public class Paciente
    {

        [JsonIgnore]
        public int Id { get; set; }
        public string? Nome { get; set; }
        public string? Email { get; set; }
        public string? Cpf { get; set; }
        public string? Telefone { get; set; }
        [JsonIgnore]
        public List<Consulta> ?Consultas { get; set; }
    }
}
