using API.Aplicacao._Contato.Comandos;
using API.Aplicacao._Contato.Consultas;
using API.Dominio.DTOs;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace Atividade03.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContatoController : ControllerBase
    {
        private readonly IContatoComandos _comandos;
        private readonly IContatoConsultas _consultas;
        public ContatoController(IContatoComandos comandos,
                                IContatoConsultas consultas)
        {
            _comandos = comandos;
            _consultas = consultas;
        }

        [HttpPost]
        [Route("Criar")]
        public async Task<IActionResult> Criar(Contato contato)
        {
            try
            {
                var resultado =  await Task.Run(() => _comandos.InserirContato(contato));
                return Ok(resultado);
            }
            catch (Exception ex) 
            { 
                throw new Exception(ex.Message, ex);
            }
        }

        [HttpPut]
        [Route("Atualizar")]
        public async Task<IActionResult> Atualizar(Contato contato)
        {
            try
            {
                var resultado = await Task.Run(() => _comandos.AtualizarContato(contato));
                return Ok(resultado);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        [HttpDelete("Excluir/{guid}")]
        public async Task<IActionResult> Excluir(string guid)
        {
            try
            {
                var resultado = await Task.Run(() => _comandos.ExcluirContato(guid));
                return Ok(resultado);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        [HttpGet]
        [Route("ObterLista")]
        public async Task<IActionResult> ObterLista()
        {
            try
            {
                var resultado = await Task.Run(() => _consultas.ObterLista());
                
                if(resultado != null)
                {
                    return Ok(resultado);
                }

                return BadRequest();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        [HttpGet("ObterListaPorDDD/{ddd}")]
        public async Task<IActionResult> ObterListaPorDDD(string ddd)
        {
            try
            {
                var resultado = await Task.Run(() => _consultas.ObterListaPorDDD(ddd));

                if (resultado != null)
                {
                    return Ok(resultado);
                }

                return BadRequest();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        [HttpGet("ObterContato/{guid}")]
        public async Task<IActionResult> ObterContato(string guid)
        {
            try
            {
                var resultado = await Task.Run(() => _consultas.ObterPorGuid(guid));

                if (resultado != null)
                {
                    return Ok(resultado);
                }

                return BadRequest();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

    }
}
