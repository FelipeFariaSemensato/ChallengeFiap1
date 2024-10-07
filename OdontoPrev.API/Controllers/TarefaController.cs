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
    public class TarefaController : ControllerBase
    {
        private readonly ITarefaService _tarefaService;

        public TarefaController(ITarefaService tarefaService)
        {
            _tarefaService = tarefaService;
        }

        [HttpPost]
        public async Task<IActionResult> CriarTarefa([FromBody] TarefaDto tarefaDto)
        {
            try
            {
                var tarefa = await _tarefaService.CriarTarefaAsync(tarefaDto);
                return Ok(tarefa);
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = ex.Message });
            }
        }

        [HttpPost("{tarefaId}/atribuir/{pacienteId}")]
        public async Task<IActionResult> AtribuirTarefa(int tarefaId, int pacienteId)
        {
            try
            {
                await _tarefaService.AtribuirTarefaAoPacienteAsync(tarefaId, pacienteId);
                return Ok(new { mensagem = "Tarefa atribuída com sucesso." });
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = ex.Message });
            }
        }

        [HttpPost("{tarefaId}/concluir/{pacienteId}")]
        public async Task<IActionResult> ConcluirTarefa(int tarefaId, int pacienteId)
        {
            try
            {
                await _tarefaService.ConcluirTarefaAsync(tarefaId, pacienteId);
                return Ok(new { mensagem = "Tarefa concluída com sucesso." });
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = ex.Message });
            }
        }

        // Outros endpoints conforme necessário
    }
}

