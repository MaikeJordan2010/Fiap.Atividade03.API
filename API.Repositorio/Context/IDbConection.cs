using Microsoft.Data.SqlClient;

namespace API.Repositorio.Context
{
    public interface IDbConection
    {
        public SqlConnection? ObterConexao();

    }
}
