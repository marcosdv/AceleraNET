using CursoAtos.Domain.Handlers;
using CursoAtos.Domain.Repositories;
using CursoAtos.Domain.Services;
using CursoAtos.Repository.Contexts;
using CursoAtos.Repository.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CursoAtos.Api.Config;

public static class ServicesExtensions
{
    public static void AddInjecaoDependencias(this IServiceCollection services, IConfigurationManager configuration)
    {
        //DI - Injecao de Dependencias

        //AddTransient -> Cria uma instancia da classe para cada chamada
        //AddScoped    -> Cria uma instancia da classe para cada requisicao completa
        //AddSingleton -> Cria uma unica instancia da classe durante toda a execucao da API, para todas as chamadas/usuarios
        
        services.AddDbContext<DataContext>(opt => opt.UseSqlServer(configuration.GetConnectionString("conexao")));

        services.AddScoped<IUsuarioRepository, UsuarioRepository>();
        services.AddScoped<INoticiaRepository, NoticiaRepository>();
        services.AddScoped<NoticiaHandler, NoticiaHandler>();
        services.AddScoped<LoginService, LoginService>();

        //DI - Injecao de Dependencias
    }
}