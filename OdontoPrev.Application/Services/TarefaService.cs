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
using System.Linq;
using System.Threading.Tasks;

namespace OdontoPrev.Application.Services
{
    public class TarefaService : ITarefaService
    {
        private readonly ITarefaRepository _tarefaRepository;
        private readonly IPacienteRepository _pacienteRepository;

        public TarefaService(ITarefaRepository tarefaRepository, IPacienteRepository pacienteRepository)
        {
            _tarefaRepository = tarefaRepository;
            _pacienteRepository = pacienteRepository;
        }

        public async Task<Tarefa> CriarTarefaAsync(TarefaDto tarefaDto)
        {
            var tarefa = new Tarefa
            {
                Descricao = tarefaDto.Descricao,
                Frequencia = tarefaDto.Frequencia,
                Pontos = CalcularPontos(tarefaDto.Frequencia),
                Concluida = false
            };

            await _tarefaRepository.AdicionarAsync(tarefa);
            return tarefa;
        }

        public async Task AtribuirTarefaAoPacienteAsync(int tarefaId, int pacienteId)
        {
            var paciente = await _pacienteRepository.ObterPorIdAsync(pacienteId);
            var tarefa = await _tarefaRepository.ObterPorIdAsync(tarefaId);

            if (paciente == null || tarefa == null)
                throw new Exception("Paciente ou Tarefa não encontrada.");

            // Verifica se a tarefa já está atribuída
            if (paciente.Tarefas.Any(t => t.Id == tarefaId))
                throw new Exception("Tarefa já atribuída a este paciente.");

            paciente.Tarefas.Add(tarefa);
            await _pacienteRepository.AtualizarAsync(paciente);
        }

        public async Task ConcluirTarefaAsync(int tarefaId, int pacienteId)
        {
            var paciente = await _pacienteRepository.ObterPorIdAsync(pacienteId);
            var tarefa = paciente.Tarefas.FirstOrDefault(t => t.Id == tarefaId);

            if (tarefa == null)
                throw new Exception("Tarefa não atribuída ao paciente.");

            if (tarefa.Concluida)
                throw new Exception("Tarefa já concluída.");

            tarefa.Concluida = true;
            paciente.AdicionarPontos(tarefa.Pontos);
            await _tarefaRepository.AtualizarAsync(tarefa);
            await _pacienteRepository.AtualizarAsync(paciente);
        }

        private int CalcularPontos(Frequencia frequencia)
        {
            return frequencia switch
            {
                Frequencia.Diario => 10,
                Frequencia.Semanal => 50,
                _ => 0,
            };
        }
    }
}

