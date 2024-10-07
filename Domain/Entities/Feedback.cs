using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OdontoPrev.Domain.Entities
{
    public class Feedback
    {
        public int Id { get; set; }
        public string Comentario { get; set; }
        public DateTime Data { get; set; }
        public int PacienteId { get; set; }
        public Paciente Paciente { get; set; }
    }
}

