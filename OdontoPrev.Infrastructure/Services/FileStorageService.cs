using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using OdontoPrev.Infrastructure.Services;
using System;
using System.IO;
using System.Threading.Tasks;

namespace OdontoPrev.Infrastructure.Services
{
    public class FileStorageService : IFileStorageService
    {
        private readonly IWebHostEnvironment _environment;

        public FileStorageService(IWebHostEnvironment environment)
        {
            _environment = environment;
        }

        public async Task<string> ArmazenarArquivoAsync(IFormFile arquivo)
        {
            var pastaDestino = Path.Combine(_environment.WebRootPath, "fotos");
            if (!Directory.Exists(pastaDestino))
                Directory.CreateDirectory(pastaDestino);

            var nomeArquivo = $"{Guid.NewGuid()}_{Path.GetFileName(arquivo.FileName)}";
            var caminhoCompleto = Path.Combine(pastaDestino, nomeArquivo);

            using (var stream = new FileStream(caminhoCompleto, FileMode.Create))
            {
                await arquivo.CopyToAsync(stream);
            }

            // Retorna a URL ou caminho relativo da foto
            return $"/fotos/{nomeArquivo}";
        }
    }
}

