using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OdontoPrev.Domain.Entities
{
    public class FotoComprovacao
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public DateTime DataEnvio { get; set; }
        public int TarefaId { get; set; }
        public Tarefa Tarefa { get; set; }
        public bool Aprovada { get; set; }
    }
}

