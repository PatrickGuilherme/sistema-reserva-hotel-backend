using Application.Filter;
using Application.IService;
using Application.ViewModel;
using Domain.MsgErro;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ExemploController : ControllerBase
    {
        private IExemploService _exemploService;

        public ExemploController(IExemploService exemploService)
        {
            _exemploService = exemploService;
        }

        [HttpPost("obter-exemplos-sql")]
        public async Task<IActionResult> Get()
        {
            try
            {
                var respostaREQ = await _exemploService.GETSQL_Exemplo();
                return Ok(respostaREQ);
            }catch(Exception erro)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, erro.Message);
            }
        }

        [HttpPost("obter-exemplos")]
        public async Task<IActionResult> Get([FromHeader] int pulo, [FromHeader] int limite, [FromBody] ExemploFiltro filtro)
        {
            try
            {
                var respostaREQ = await _exemploService.GET_Exemplo(pulo, limite, filtro);
                return Ok(respostaREQ);
            }
            catch (Exception erro)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, erro.Message);
            }
        }

        [HttpPost("cadastrar-exemplo")]
        public async Task<IActionResult> Post([FromBody] ExemploViewModel exemplo)
        {
            if (exemplo == null) return this.StatusCode(StatusCodes.Status400BadRequest, MsgErro.ErroCadastroParametros);
            try
            {
                var respostaREQ = await _exemploService.Create(exemplo);
                return Ok(respostaREQ);
            }
            catch (Exception erro)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, erro.Message);

            }
        }
        
        [HttpPut("editar-exemplo")]
        public async Task<IActionResult> Put([FromBody] ExemploViewModel exemplo)
        {
            if (exemplo == null) return this.StatusCode(StatusCodes.Status400BadRequest, MsgErro.ErroCadastroParametros);

            try
            {
                var respostaREQ = await _exemploService.Update(exemplo);
                return Ok(respostaREQ);
            }
            catch (Exception erro)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, erro.Message);
            }
        }
    
        [HttpPatch("desabilitar-exemplo")]
        public async Task<IActionResult> Disable([FromHeader] int id) 
        {
            if(id <= 0) return this.StatusCode(StatusCodes.Status400BadRequest, MsgErro.ErroCadastroParametros);

            try
            {
                var respostaREQ = await _exemploService.Disable(id);
                return Ok(respostaREQ);
            }
            catch (Exception erro)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, erro.Message);
            }
        }
    }
}
