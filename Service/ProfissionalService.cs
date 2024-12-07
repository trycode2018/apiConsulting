﻿using Consultorio.DTOs;
using Consultorio.Interfaces;
using Consultorio.Models;
using System.Runtime;

namespace Consultorio.Service
{
    public class ProfissionalService:IProfissionalService
    {
        private readonly IProfissionalRepository _repository;
        public ProfissionalService(IProfissionalRepository repository) => _repository = repository;

        public async Task AddAsync(ProfissionalDTO profissionalDTO)
        {
            var profissional = new Profissional
            {
                Nome = profissionalDTO.Nome,
                Ativo = profissionalDTO.Ativo
            };
            await _repository.AddAsync(profissional);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }

        public async Task<IEnumerable<ProfissionalDTO>> GetAllAsync()
        {
            var profissionais = await _repository.GetAllAsync();
            return profissionais.Select(p => new ProfissionalDTO
            {
                Nome = p.Nome,
                Ativo= p.Ativo
            });
        }

        public async Task<ProfissionalDTO> GetByIdAsync(int id)
        {
            var profissional = await _repository.GetByIdAsync(id);
            return new ProfissionalDTO
            {
                Nome = profissional.Nome,
                Ativo = profissional.Ativo
            };
        }

        public async Task UpdateAsync(int id, ProfissionalDTO profissionalDTO)
        {
            var profissional = await _repository.GetByIdAsync(id);
            if(profissional != null)
            {
                profissional.Nome = profissionalDTO.Nome;
                profissional.Ativo = profissionalDTO.Ativo;
                await _repository.UpdateAsync(profissional);
            }
        }
    }
}