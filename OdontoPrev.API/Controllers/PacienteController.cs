namespace OdontoPrev.API.Controllers
using global::OdontoPrev.Application.DTOs;
using global::OdontoPrev.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using OdontoPrev.Application.DTOs;
using OdontoPrev.Application.Interfaces;
using OdontoPrev.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace OdontoPrev.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PacienteController : ControllerBase
    {
        private readonly IPacienteService _pacienteService;

        public PacienteController(IPacienteService pacienteService)
        {
            _pacienteService = pacienteService;
        }

        [HttpPost]
        public async Task<IActionResult> RegistrarPaciente([FromBody] PacienteDto pacienteDto)
        {
            try
            {
                var paciente = await _pacienteService.RegistrarPacienteAsync(pacienteDto);
                return Ok(paciente);
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = ex.Message });
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObterPacientePorId(int id)
        {
            var paciente = await _pacienteService.ObterPacientePorIdAsync(id);
            if (paciente == null)
                return NotFound(new { mensagem = "Paciente não encontrado." });

            return Ok(paciente);
        }

        // Outros endpoints conforme necessário
    }
}

