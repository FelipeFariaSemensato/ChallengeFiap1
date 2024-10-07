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
using System.Threading.Tasks;

namespace OdontoPrev.Infrastructure.Repositories
{
    public class PacienteRepository : IPacienteRepository
    {
        private readonly AppDbContext _context;

        public PacienteRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AdicionarAsync(Paciente entidade)
        {
            await _context.Pacientes.AddAsync(entidade);
            await _context.SaveChangesAsync();
        }

        public async Task<Paciente> ObterPorEmailAsync(string email)
        {
            return await _context.Pacientes
                                 .Include(p => p.Tarefas)
                                 .Include(p => p.Feedbacks)
                                 .Include(p => p.Mensagens)
                                 .FirstOrDefaultAsync(p => p.Email == email);
        }

        public async Task<Paciente> ObterPorIdAsync(int id)
        {
            return await _context.Pacientes
                                 .Include(p => p.Tarefas)
                                 .Include(p => p.Feedbacks)
                                 .Include(p => p.Mensagens)
                                 .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<Paciente>> ObterTodosAsync()
        {
            return await _context.Pacientes
                                 .Include(p => p.Tarefas)
                                 .Include(p => p.Feedbacks)
                                 .Include(p => p.Mensagens)
                                 .ToListAsync();
        }

        public async Task RemoverAsync(int id)
        {
            var paciente = await _context.Pacientes.FindAsync(id);
            if (paciente != null)
            {
                _context.Pacientes.Remove(paciente);
                await _context.SaveChangesAsync();
            }
        }

        public async Task AtualizarAsync(Paciente entidade)
        {
            _context.Pacientes.Update(entidade);
            await _context.SaveChangesAsync();
        }
    }
}

