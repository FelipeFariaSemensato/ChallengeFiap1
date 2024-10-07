using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OdontoPrev.Domain.Entities;

namespace OdontoPrev.Application.DTOs
{
    public class TarefaDto
    {
        public string Descricao { get; set; }
        public Frequencia Frequencia { get; set; }
    }
}
