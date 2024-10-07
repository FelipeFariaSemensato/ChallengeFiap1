using Microsoft.AspNetCore.Mvc;
using OdontoPrev.Application.DTOs;
using OdontoPrev.Application.Interfaces;
using OdontoPrev.Application.Services;
using System;
using System.Threading.Tasks;

namespace OdontoPrev.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FotoComprovacaoController : ControllerBase
    {
        private readonly IFotoComprovacaoService _fotoService;

        public FotoComprovacaoController(IFotoComprovacaoService fotoService)
        {
            _fotoService = fotoService;
        }

        [HttpPost]
        public async Task<IActionResult> EnviarFoto([FromForm] FotoComprovacaoDto fotoDto)
        {
            try
            {
                await _fotoService.EnviarFotoAsync(fotoDto);
                return Ok(new { mensagem = "Foto enviada com sucesso." });
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = ex.Message });
            }
        }

        [HttpPost("validar/{fotoId}")]
        public async Task<IActionResult> ValidarFoto(int fotoId)
        {
            try
            {
                await _fotoService.ValidarFotoAsync(fotoId);
                return Ok(new { mensagem = "Foto validada com sucesso." });
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = ex.Message });
            }
        }

        // Outros endpoints conforme necessário
    }
}

