using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace OdontoPrev.Application.DTOs
{
    public class FotoComprovacaoDto
    {
        public int TarefaId { get; set; }
        public IFormFile Foto { get; set; }
    }
}
