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
    public interface ITarefaService
    {
        Task<Tarefa> CriarTarefaAsync(TarefaDto tarefaDto);
        Task AtribuirTarefaAoPacienteAsync(int tarefaId, int pacienteId);
        Task ConcluirTarefaAsync(int tarefaId, int pacienteId);
    }
}

