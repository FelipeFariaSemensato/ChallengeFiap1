using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OdontoPrev.Domain.Entities
{
    public class Dentista
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public ICollection<Mensagem> Mensagens { get; set; } = new List<Mensagem>();
    }
}

