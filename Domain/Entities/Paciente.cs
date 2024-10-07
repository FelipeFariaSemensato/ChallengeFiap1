using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OdontoPrev.Domain.Entities
{
    public class Paciente
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public int Pontos { get; set; }
        public NivelRecompensa NivelRecompensa { get; set; }
        public ICollection<Tarefa> Tarefas { get; set; } = new List<Tarefa>();
        public ICollection<Feedback> Feedbacks { get; set; } = new List<Feedback>();
        public ICollection<Mensagem> Mensagens { get; set; } = new List<Mensagem>();

        public void AdicionarPontos(int pontos)
        {
            Pontos += pontos;
            AtualizarNivel();
        }

        private void AtualizarNivel()
        {
            if (Pontos >= 1000)
                NivelRecompensa = NivelRecompensa.Ouro;
            else if (Pontos >= 500)
                NivelRecompensa = NivelRecompensa.Prata;
            else
                NivelRecompensa = NivelRecompensa.Bronze;
        }
    }

    public enum NivelRecompensa
    {
        Bronze,
        Prata,
        Ouro
    }
}
