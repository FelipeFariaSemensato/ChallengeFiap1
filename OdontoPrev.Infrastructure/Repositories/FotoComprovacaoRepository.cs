using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OdontoPrev.Domain.Entities;
using OdontoPrev.Domain.Interfaces;
using OdontoPrev.Infrastructure.Persistence;
using System.Threading.Tasks;

namespace OdontoPrev.Infrastructure.Repositories
{
    public class FotoComprovacaoRepository : IRepositorioGenerico<FotoComprovacao>
    {
        private readonly AppDbContext _context;

        public FotoComprovacaoRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AdicionarAsync(FotoComprovacao entidade)
        {
            await _context.FotosComprovacao.AddAsync(entidade);
            await _context.SaveChangesAsync();
        }

        public async Task<FotoComprovacao> ObterPorIdAsync(int id)
        {
            return await _context.FotosComprovacao
                                 .Include(f => f.Tarefa)
                                 .FirstOrDefaultAsync(f => f.Id == id);
        }

        public async Task AtualizarAsync(FotoComprovacao entidade)
        {
            _context.FotosComprovacao.Update(entidade);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<FotoComprovacao>> ObterTodosAsync()
        {
            return await _context.FotosComprovacao.Include(f => f.Tarefa).ToListAsync();
        }

        public async Task RemoverAsync(int id)
        {
            var foto = await _context.FotosComprovacao.FindAsync(id);
            if (foto != null)
            {
                _context.FotosComprovacao.Remove(foto);
                await _context.SaveChangesAsync();
            }
        }
    }
}

