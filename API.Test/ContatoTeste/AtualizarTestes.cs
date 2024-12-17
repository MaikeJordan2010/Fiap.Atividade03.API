using API.Aplicacao._Contato.Comandos;
using API.Aplicacao._Services;
using API.Dominio.DTOs;
using API.Dominio.Sistemicas;
using Moq;

namespace API.Test.InserirTeste
{
    public class AtualizarTestes
    {
        private readonly Mock<IMessageBroker> _messageBroker;
        private IContatoComandos? _contatoComandos;
        public AtualizarTestes()
        {
            _messageBroker = new Mock<IMessageBroker>();
        }

        [Fact]
        public async Task Atualizar_Passando_Parametros_Incorretor()
        {

            var contato = new Contato()
            {
                Guid = Guid.NewGuid().ToString(),
                Nome = null,
                Email = null,
            };

            _contatoComandos = new ContatoComandos(_messageBroker.Object);

            ResultadoGenerico resultado = await _contatoComandos.AtualizarContato(contato);

            Assert.False(resultado.Sucesso);
        }

        [Fact]
        public async Task Atualizar_Passando_Parametros_Corretor()
        {

            var contato = new Contato()
            {
                Guid = Guid.NewGuid().ToString(),
                Nome = "Maike",
                Email = "maikejordan@kria.com",
                DDD = "11",
                Telefone = "999999999",
                Estado = "SP",
                Municipio = "Guarulhos" 
            };

            _contatoComandos = new ContatoComandos(_messageBroker.Object);

            ResultadoGenerico resultado = await _contatoComandos.AtualizarContato(contato);

            Assert.True(resultado.Sucesso);
        }

    }
}