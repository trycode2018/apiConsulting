﻿namespace Consultorio.DTOs.Pacientes
{
    public class PacienteAtualizarDTO
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public string? Email { get; set; }
        public string? Cpf { get; set; }
        public string? Telefone { get; set; }
    }
}
