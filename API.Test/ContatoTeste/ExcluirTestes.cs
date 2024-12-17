using API.Aplicacao._Contato.Comandos;
using API.Aplicacao._Services;
using API.Dominio.DTOs;
using API.Dominio.Sistemicas;
using Moq;

namespace API.Test.InserirTeste
{
    public class ExcluirTestes
    {
        private readonly Mock<IMessageBroker> _messageBroker;
        private IContatoComandos? _contatoComandos;
        public ExcluirTestes()
        {
            _messageBroker = new Mock<IMessageBroker>();
        }

        [Fact]
        public async Task Excluindo_Passando_Parametros_Incorretor()
        {

            _contatoComandos = new ContatoComandos(_messageBroker.Object);

            ResultadoGenerico resultado = await _contatoComandos.ExcluirContato(string.Empty);

            Assert.False(resultado.Sucesso);
        }

        [Fact]
        public async Task Criar_Passando_Parametros_Corretor()
        {

            var contato = new Contato()
            {
                Guid = Guid.NewGuid().ToString(),
            };

            _contatoComandos = new ContatoComandos(_messageBroker.Object);

            ResultadoGenerico resultado = await _contatoComandos.ExcluirContato(contato.Guid);

            Assert.True(resultado.Sucesso);
        }

    }
}