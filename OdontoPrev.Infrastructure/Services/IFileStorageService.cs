using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace OdontoPrev.Infrastructure.Services
{
    public interface IFileStorageService
    {
        Task<string> ArmazenarArquivoAsync(IFormFile arquivo);
    }
}

