using API.Dominio.DTOs;

namespace API.Aplicacao._Services
{
    public interface IMessageBroker
    {
        public Task CadastrarContato(Contato contato);
        public Task AtualizarContato(Contato contato);
        public Task ExcluirContato(Contato contato);

    }
}
