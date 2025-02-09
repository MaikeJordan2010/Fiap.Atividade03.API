using API.Repositorio.Context;
using API.Repositorio.Repositorios.ContatosRepositorio.Consultas;
using Microsoft.Extensions.DependencyInjection;

namespace API.Aplicacao.Injecao
{
    public static class InjecaoDeDependencias
    {
        public static void AddInfraestrutura(this IServiceCollection services)
        {

            services.AddScoped<IDbConection, DbConection>();
            services.AddScoped<IContatoConsultaRepositorio, ContatoConsultaRepositorio>();
        }
    }
}
