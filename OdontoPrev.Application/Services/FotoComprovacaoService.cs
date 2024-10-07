using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using OdontoPrev.Application.DTOs;
using OdontoPrev.Application.Interfaces;
using OdontoPrev.Domain.Entities;
using OdontoPrev.Domain.Interfaces;
using OdontoPrev.Infrastructure.Services;
using System;
using System.Threading.Tasks;

namespace OdontoPrev.Application.Services
{
    public class FotoComprovacaoService : IFotoComprovacaoService
    {
        private readonly IRepositorioGenerico<FotoComprovacao> _fotoRepository;
        private readonly ITarefaRepository _tarefaRepository;
        private readonly IPacienteRepository _pacienteRepository;
        private readonly IFileStorageService _fileStorageService;
        private readonly FotoValidationService _validationService;

        public FotoComprovacaoService(
            IRepositorioGenerico<FotoComprovacao> fotoRepository,
            ITarefaRepository tarefaRepository,
            IPacienteRepository pacienteRepository,
            IFileStorageService fileStorageService,
            FotoValidationService validationService)
        {
            _fotoRepository = fotoRepository;
            _tarefaRepository = tarefaRepository;
            _pacienteRepository = pacienteRepository;
            _fileStorageService = fileStorageService;
            _validationService = validationService;
        }

        public async Task EnviarFotoAsync(FotoComprovacaoDto fotoDto)
        {
            var tarefa = await _tarefaRepository.ObterPorIdAsync(fotoDto.TarefaId);
            if (tarefa == null)
                throw new Exception("Tarefa não encontrada.");

            var urlFoto = await _fileStorageService.ArmazenarArquivoAsync(fotoDto.Foto);

            var foto = new FotoComprovacao
            {
                Url = urlFoto,
                DataEnvio = DateTime.UtcNow,
                TarefaId = fotoDto.TarefaId,
                Aprovada = false
            };

            await _fotoRepository.AdicionarAsync(foto);
        }

        public async Task ValidarFotoAsync(int fotoId)
        {
            var foto = await _fotoRepository.ObterPorIdAsync(fotoId);
            if (foto == null)
                throw new Exception("Foto não encontrada.");

            foto.Aprovada = await _validationService.ValidarFotoAsync(foto.Url);
            await _fotoRepository.AtualizarAsync(foto);

            if (foto.Aprovada)
            {
                var tarefa = await _tarefaRepository.ObterPorIdAsync(foto.TarefaId);
                tarefa.Concluida = true;
                await _tarefaRepository.AtualizarAsync(tarefa);

                var paciente = await _pacienteRepository.ObterPorIdAsync(tarefa.PacientesId); // Supondo que há uma relação
                paciente.AdicionarPontos(tarefa.Pontos);
                await _pacienteRepository.AtualizarAsync(paciente);
            }
        }
    }
}

