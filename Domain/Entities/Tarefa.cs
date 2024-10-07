using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OdontoPrev.Domain.Entities
{
    public class Tarefa
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public Frequencia Frequencia { get; set; }
        public int Pontos { get; set; }
        public ICollection<FotoComprovacao> FotosComprovacao { get; set; } = new List<FotoComprovacao>();
        public bool Concluida { get; set; }
    }

    public enum Frequencia
    {
        Diario,
        Semanal
    }
}

