using API.Dominio.DTOs;
using API.Repositorio.Context;
using Dapper;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;
using System;
using System.Linq.Expressions;
using System.Text;

namespace API.Repositorio.Repositorios.ContatosRepositorio.Consultas
{
    public class ContatoConsultaRepositorio : IContatoConsultaRepositorio
    {
        private readonly SqlConnection? _connection;

        public ContatoConsultaRepositorio(IDbConection connection)
        {
            _connection = connection.ObterConexao();
        }
        public Contato? ObterContatoPorEmail(string email)
        {
            try
            {
                if(_connection != null)
                {
                    _connection.Open();

                    var query = new StringBuilder();
                    query.Append("SELECT * FROM TabContatos ");
                    query.Append("WHERE Email = ?email ");

                   var resultado =  _connection.Query<Contato>(query.ToString(), new { email = email }).FirstOrDefault();

                    return resultado ?? default;
                }

                return default;
            }
            catch (Exception ex) 
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                _connection?.Close();
            }
        }

        public Contato? ObterContatoPorGuid(string guid)
        {
            try
            {
                if (_connection != null)
                {
                    _connection.Open();

                    var query = new StringBuilder();
                    query.Append("SELECT * FROM TabContatos ");
                    query.Append("WHERE Guid = ?guid ");

                    var resultado = _connection.Query<Contato>(query.ToString(), new { guid = guid }).FirstOrDefault();

                    return resultado ?? default;
                }

                return default;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                _connection?.Close();
            }
        }

        public IEnumerable<Contato> ObterLista()
        {
            try
            {
                if (_connection != null)
                {
                    _connection.Open();

                    var query = new StringBuilder();
                    query.Append("SELECT * FROM TabContatos ");
                    query.Append("WHERE Guid = ?guid ");

                    var resultado = _connection.GetAll<Contato>();

                    return resultado ?? Enumerable.Empty<Contato>();
                }

                return Enumerable.Empty<Contato>();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                _connection?.Close();
            }
        }

        public IEnumerable<Contato> ObterListaPorDDD(string ddd)
        {
            try
            {
                if (_connection != null)
                {
                    _connection.Open();

                    var query = new StringBuilder();
                    query.Append("SELECT * FROM TabContatos ");
                    query.Append("WHERE DDD = ?ddd ");

                    var resultado = _connection.Query<Contato>(query.ToString(), new { ddd = ddd });

                    return resultado ?? Enumerable.Empty<Contato>();
                }

                return Enumerable.Empty<Contato>();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                _connection?.Close();
            }
        }
    }
}
