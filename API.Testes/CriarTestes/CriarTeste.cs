using API.Aplicacao._Contato.Comandos;
using API.Aplicacao._Services;
using API.Dominio.DTOs;
using API.Dominio.Sistemicas;
using Moq;
using Xunit;

namespace API.Testes.CriarTestes
{
    public class CriarTeste
    {

        private readonly Mock<IMessageBroker> _messageBroker;
        private IContatoComandos? _contatoComandos;
        public CriarTeste()
        {
            _messageBroker = new Mock<IMessageBroker>();
        }

        [Fact]
        public async Task Criar_Passando_Parametros_Incorretor()
        {

            var contato = new Contato()
            {
                Guid = Guid.NewGuid().ToString(),
                Nome = null,
                Email = null,
            };

            _contatoComandos = new ContatoComandos(_messageBroker.Object);

            ResultadoGenerico resultado = await _contatoComandos.InserirContato(contato);

            Assert.False(resultado.Sucesso);
        }
    }
}
