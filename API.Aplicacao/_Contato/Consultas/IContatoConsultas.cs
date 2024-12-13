using API.Dominio.DTOs;

namespace API.Aplicacao._Contato.Consultas
{
    public interface IContatoConsultas
    {
        public Task<IEnumerable<Contato>> ObterLista();
        public Task<IEnumerable<Contato>> ObterListaPorDDD(string ddd);
        public Task<Contato?> ObterPorEmail(string email);
        public Task<Contato?> ObterPorGuid(string guid);

    }
}
