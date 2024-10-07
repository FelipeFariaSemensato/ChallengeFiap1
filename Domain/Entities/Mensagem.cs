using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OdontoPrev.Domain.Entities
{
    public class Mensagem
    {
        public int Id { get; set; }
        public string Conteudo { get; set; }
        public DateTime DataEnvio { get; set; }
        public int PacienteId { get; set; }
        public Paciente Paciente { get; set; }
        public int DentistaId { get; set; }
        public Dentista Dentista { get; set; }
    }
}

