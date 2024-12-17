using API.Aplicacao._Contato.Consultas;
using API.Dominio.DTOs;
using API.Repositorio.Repositorios.ContatosRepositorio.Consultas;
using Moq;

namespace API.Test.ContatoTeste
{
    public class ObterDadosTestes
    {
        private readonly Mock<IContatoConsultaRepositorio> _repositorio;
        private IContatoConsultas? _contatoConsultas;
        public ObterDadosTestes()
        {
            _repositorio = new Mock<IContatoConsultaRepositorio>();
        }

        [Fact]
        public async Task ObterLista()
        {
            _repositorio.Setup(x => x.ObterLista()).Returns(Enumerable.Empty<Contato>());

            _contatoConsultas = new ContatoConsultas(_repositorio.Object);

            var resultado = await _contatoConsultas.ObterLista();

            Assert.NotNull(resultado);
        }

        [Fact]
        public async Task Obter_Lista_Por_ddd()
        {
            _repositorio.Setup(x => x.ObterListaPorDDD(It.IsAny<string>())).Returns(Enumerable.Empty<Contato>());

            _contatoConsultas = new ContatoConsultas(_repositorio.Object);

            var resultado = await _contatoConsultas.ObterLista();

            Assert.NotNull(resultado);
        }


        [Fact]
        public async Task Obter_Por_Guid()
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

            _repositorio.Setup(x => x.ObterContatoPorGuid(It.IsAny<string>())).Returns(contato);

            _contatoConsultas = new ContatoConsultas(_repositorio.Object);

            var resultado = await _contatoConsultas.ObterLista();

            Assert.NotNull(resultado);
        }


        [Fact]
        public async Task Obter_Por_Email()
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

            _repositorio.Setup(x => x.ObterContatoPorEmail(It.IsAny<string>())).Returns(contato);

            _contatoConsultas = new ContatoConsultas(_repositorio.Object);

            var resultado = await _contatoConsultas.ObterLista();

            Assert.NotNull(resultado);
        }


    }
}
