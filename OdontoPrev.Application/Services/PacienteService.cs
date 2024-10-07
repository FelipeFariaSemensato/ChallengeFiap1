using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OdontoPrev.Application.DTOs;
using OdontoPrev.Application.Interfaces;
using OdontoPrev.Domain.Entities;
using OdontoPrev.Domain.Interfaces;
using System;
using System.Threading.Tasks;

namespace OdontoPrev.Application.Services
{
    public class PacienteService : IPacienteService
    {
        private readonly IPacienteRepository _pacienteRepository;

        public PacienteService(IPacienteRepository pacienteRepository)
        {
            _pacienteRepository = pacienteRepository;
        }

        public async Task<Paciente> RegistrarPacienteAsync(PacienteDto pacienteDto)
        {
            var pacienteExistente = await _pacienteRepository.ObterPorEmailAsync(pacienteDto.Email);
            if (pacienteExistente != null)
                throw new Exception("Paciente já registrado com este email.");

            var paciente = new Paciente
            {
                Nome = pacienteDto.Nome,
                Email = pacienteDto.Email,
                Pontos = 0,
                NivelRecompensa = NivelRecompensa.Bronze
            };

            await _pacienteRepository.AdicionarAsync(paciente);
            return paciente;
        }

        public async Task<Paciente> ObterPacientePorIdAsync(int id)
        {
            return await _pacienteRepository.ObterPorIdAsync(id);
        }

    }
}

