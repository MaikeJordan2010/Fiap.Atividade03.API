using API.Dominio.DTOs;
using Newtonsoft.Json;
using RabbitMQ.Client;
using System.Text;

namespace API.Aplicacao._Services
{
    public class MessageBroker : IMessageBroker
    {
        private readonly ConnectionFactory? _factory;
        public MessageBroker()
        {
            _factory = new ConnectionFactory()
            {
                HostName = "localhost",
                UserName = "guest",
                Password = "guest",
                
            };

        }

        public async Task CadastrarContato(Contato contato)
        {
            try
            {
                string nomeFila = "contato.fila.cadastrar";
                using var connection = await _factory!.CreateConnectionAsync();
                using (var channel = await connection.CreateChannelAsync())
                {
                    await channel.QueueDeclareAsync(
                        queue: nomeFila, 
                        durable: false, 
                        exclusive: false, 
                        autoDelete: false,
                        arguments: null
                    );

                    var mensagem = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(contato));

                    await channel.BasicPublishAsync(
                        exchange: string.Empty, 
                        routingKey: nomeFila,
                        body: mensagem
                    );

                }
            }
            catch (Exception ex) 
            { 
                throw new Exception(ex.Message, ex);
            }

        }


        public async Task AtualizarContato(Contato contato)
        {
            try
            {
                string nomeFila = "contato.fila.atualizar";
                using var connection = await _factory!.CreateConnectionAsync();
                using (var channel = await connection.CreateChannelAsync())
                {
                    await channel.QueueDeclareAsync(
                        queue: nomeFila,
                        durable: false,
                        exclusive: false,
                        autoDelete: false,
                        arguments: null
                    );

                    var mensagem = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(contato));

                    await channel.BasicPublishAsync(
                        exchange: string.Empty,
                        routingKey: nomeFila,
                        body: mensagem
                    );

                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }

        }

        public async Task ExcluirContato(Contato contato)
        {
            try
            {
                string nomeFila = "contato.fila.excluir";
                using var connection = await _factory!.CreateConnectionAsync();
                using (var channel = await connection.CreateChannelAsync())
                {
                    await channel.QueueDeclareAsync(
                        queue: nomeFila,
                        durable: false,
                        exclusive: false,
                        autoDelete: false,
                        arguments: null
                    );

                    var mensagem = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(contato));

                    await channel.BasicPublishAsync(
                        exchange: string.Empty,
                        routingKey: nomeFila,
                        body: mensagem
                    );

                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }

        }

    }
}
