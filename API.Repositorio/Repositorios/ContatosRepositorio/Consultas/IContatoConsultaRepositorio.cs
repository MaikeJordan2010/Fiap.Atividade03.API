using API.Dominio.DTOs;

namespace API.Repositorio.Repositorios.ContatosRepositorio.Consultas
{
    public interface IContatoConsultaRepositorio
    {
        public Contato? ObterContatoPorGuid(string guid);
        public Contato? ObterContatoPorEmail(string email);
        public IEnumerable<Contato> ObterLista();
        public IEnumerable<Contato> ObterListaPorDDD(string ddd);

    }
}
