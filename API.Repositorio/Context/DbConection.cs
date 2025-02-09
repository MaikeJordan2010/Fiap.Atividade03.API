using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace API.Repositorio.Context
{ 
    public class DbConection : IDbConection
    {

        private SqlConnection? _sqlConnection;
        private readonly IConfiguration _config;

        public DbConection(IConfiguration config)
        {
            _config = config;
        }


        public SqlConnection? ObterConexao()
        {
            var stringConexao = _config.GetConnectionString("DefaultConnection");
            try
            {
                if (_sqlConnection == null) {


                    _sqlConnection = new SqlConnection(stringConexao);
                    return _sqlConnection;
                }

                return _sqlConnection;
            }
            catch (Exception ex)
            {
                throw new Exception($"SEGUE STRING DE CONEXÃO:{stringConexao}");
            }
        }
      
    }
}
