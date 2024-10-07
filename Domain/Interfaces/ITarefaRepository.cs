using OdontoPrev.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OdontoPrev.Domain.Interfaces
{
    public interface ITarefaRepository : IRepositorioGenerico<Tarefa>
    {
        Task<IEnumerable<Tarefa>> ObterTarefasPorPacienteAsync(int pacienteId);
    }
}
