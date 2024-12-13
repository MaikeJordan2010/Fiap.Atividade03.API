using API.Dominio.DTOs;
using API.Repositorio.Repositorios.ContatosRepositorio.Consultas;

namespace API.Aplicacao._Contato.Consultas
{
    public class ContatoConsultas : IContatoConsultas
    {
        private readonly IContatoConsultaRepositorio _contatoConsultaRepositorio;

        public ContatoConsultas(IContatoConsultaRepositorio contatoConsultaRepositorio)
        {
            _contatoConsultaRepositorio = contatoConsultaRepositorio;
        }
        public Task<IEnumerable<Contato>> ObterLista()
        {
            try
            {
                var resultado = _contatoConsultaRepositorio.ObterLista();

                return Task.FromResult(resultado);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Task<IEnumerable<Contato>> ObterListaPorDDD(string ddd)
        {
            try
            {
                if(!string.IsNullOrEmpty(ddd))
                {
                    var resultado = _contatoConsultaRepositorio.ObterListaPorDDD(ddd);

                    return Task.FromResult(resultado);
                }

                return Task.FromResult(Enumerable.Empty<Contato>());
            }
            catch (Exception ex) 
            { 
                throw new Exception(ex.Message);
            }
        }

        public Task<Contato?> ObterPorEmail(string email)
        {
            try
            {
                if (!string.IsNullOrEmpty(email))
                {
                    var resultado = _contatoConsultaRepositorio.ObterContatoPorEmail(email);

                    return Task.FromResult(resultado);
                }

                return default;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Task<Contato?> ObterPorGuid(string guid)
        {
            try
            {
                if (!string.IsNullOrEmpty(guid))
                {
                    var resultado = _contatoConsultaRepositorio.ObterContatoPorGuid(guid);

                    return Task.FromResult(resultado);
                }

                return default;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
