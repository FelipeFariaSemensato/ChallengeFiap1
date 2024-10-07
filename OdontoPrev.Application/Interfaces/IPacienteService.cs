using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OdontoPrev.Application.DTOs;
using OdontoPrev.Domain.Entities;
using System.Threading.Tasks;

namespace OdontoPrev.Application.Interfaces
{
    public interface IPacienteService
    {
        Task<Paciente> RegistrarPacienteAsync(PacienteDto pacienteDto);
        Task<Paciente> ObterPacientePorIdAsync(int id);
    }
}
