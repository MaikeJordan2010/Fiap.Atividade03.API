using API.Dominio.DTOs;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using RabbitMQ.Client;
using System.Text;

namespace API.Aplicacao._Services
{
    public class MessageBroker : IMessageBroker
    {
        private readonly ConnectionFactory? _factory;
        public MessageBroker(IConfiguration config)
        {
            _factory = new ConnectionFactory()
            {
                HostName = config.GetSection("RabbitLocal").GetSection("Endereco").Value ?? "localhost",
                UserName = config.GetSection("RabbitLocal").GetSection("Usuario").Value ?? "guest",
                Password = config.GetSection("RabbitLocal").GetSection("Senha").Value ?? "guest",
                Port = Convert.ToInt32(config.GetSection("RabbitLocal").GetSection("Porta").Value)
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
