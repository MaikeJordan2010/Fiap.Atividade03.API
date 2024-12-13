using API.Dominio.DTOs;
using API.Dominio.Sistemicas;

namespace API.Aplicacao._Contato.Comandos
{
    public interface IContatoComandos
    {
        public Task<ResultadoGenerico> InserirContato(Contato contato);
        public Task<ResultadoGenerico> AtualizarContato(Contato contato);
        public Task<ResultadoGenerico> ExcluirContato(string guid);

    }
}
