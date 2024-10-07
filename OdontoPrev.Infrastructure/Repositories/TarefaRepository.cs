using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OdontoPrev.Domain.Entities;
using OdontoPrev.Domain.Interfaces;
using OdontoPrev.Infrastructure.Persistence;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OdontoPrev.Infrastructure.Repositories
{
    public class TarefaRepository : ITarefaRepository
    {
        private readonly AppDbContext _context;

        public TarefaRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AdicionarAsync(Tarefa entidade)
        {
            await _context.Tarefas.AddAsync(entidade);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Tarefa>> ObterTarefasPorPacienteAsync(int pacienteId)
        {
            return await _context.Pacientes
                                 .Where(p => p.Id == pacienteId)
                                 .SelectMany(p => p.Tarefas)
                                 .ToListAsync();
        }

        public async Task<Tarefa> ObterPorIdAsync(int id)
        {
            return await _context.Tarefas
                                 .Include(t => t.FotosComprovacao)
                                 .FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task<IEnumerable<Tarefa>> ObterTodosAsync()
        {
            return await _context.Tarefas
                                 .Include(t => t.FotosComprovacao)
                                 .ToListAsync();
        }

        public async Task RemoverAsync(int id)
        {
            var tarefa = await _context.Tarefas.FindAsync(id);
            if (tarefa != null)
            {
                _context.Tarefas.Remove(tarefa);
                await _context.SaveChangesAsync();
            }
        }

        public async Task AtualizarAsync(Tarefa entidade)
        {
            _context.Tarefas.Update(entidade);
            await _context.SaveChangesAsync();
        }
    }
}

