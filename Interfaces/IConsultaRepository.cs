﻿using Consultorio.Models;

namespace Consultorio.Interfaces
{
    public interface IConsultaRepository
    {
        Task<IEnumerable<Consulta>> GetAllAsync();
        Task<Consulta> GetByIdAsync(int id);
        Task AddAsync(Consulta consulta);
        Task UpdateAsync(Consulta consulta);
        Task DeleteAsync(int id);
    }
}
