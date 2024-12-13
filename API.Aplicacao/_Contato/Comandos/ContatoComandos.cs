using API.Aplicacao._Services;
using API.Dominio.DTOs;
using API.Dominio.Sistemicas;
using API.Dominio.Validadores.ValidarContato;

namespace API.Aplicacao._Contato.Comandos
{
    public class ContatoComandos : IContatoComandos
    {
        private IMessageBroker _messageBroker;
        public ContatoComandos(IMessageBroker messageBroker)
        {
            _messageBroker = messageBroker;
        }

        public async Task<ResultadoGenerico> InserirContato(Contato contato)
        {
            try
            {
                var validador = new ValidarCadastrarContato().Validate(contato);

                if (validador.IsValid)
                {
                    await _messageBroker.CadastrarContato(contato);
                    return await Task.FromResult(new ResultadoGenerico(true, "Sucesso ao adicionar item na fila  de criação!"));
                }

                return await Task.FromResult(new ResultadoGenerico(false, "Erro ao adicionar item na fila  de criação!", validador.Errors));

            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }


        public async Task<ResultadoGenerico> AtualizarContato(Contato contato)
        {
            try
            {
                var validador = new ValidarCadastrarContato().Validate(contato);

                if (validador.IsValid)
                {
                    await _messageBroker.AtualizarContato(contato);
                    return await Task.FromResult(new ResultadoGenerico(true, "Sucesso ao adicionar item na fila  de atualização!"));
                }

                return await Task.FromResult(new ResultadoGenerico(false, "Erro ao adicionar item na fila  de gravação!", validador.Errors));

            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public async Task<ResultadoGenerico> ExcluirContato(string guid)
        {
            try
            {
                if (!string.IsNullOrEmpty(guid))
                {
                    await _messageBroker.ExcluirContato(new Contato() { Guid = guid });
                    return await Task.FromResult(new ResultadoGenerico(true, "Sucesso ao adicionar item na fila  de exclusão!"));
                }

                return await Task.FromResult(new ResultadoGenerico(false, "Erro ao adicionar item na fila  de exclusão!"));

            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

    }
}
