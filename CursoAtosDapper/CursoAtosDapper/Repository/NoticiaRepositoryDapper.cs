using CursoAtosDapper.Models;
using CursoAtosDapper.Repository.Interfaces;
using Dapper;
using Microsoft.Data.SqlClient;

namespace CursoAtosDapper.Repository;

public class NoticiaRepositoryDapper : INoticiaRepository
{
    private readonly SqlConnection _connection;

    public NoticiaRepositoryDapper(SqlConnection connection)
    {
        _connection = connection;
        _connection.Open();
    }

    public async void Inserir(Noticia noticia)
    {
        var sql = @"INSERT INTO TbNoticia (NotTitulo, NotTexto, NotUltimaAtualizacao)
                                   VALUES (@Titulo, @Texto, @UltimaAtualizacao)";

        var parametros = new
        {
            noticia.Titulo,
            noticia.Texto,
            noticia.UltimaAtualizacao
        };

        await _connection.ExecuteAsync(sql, parametros);
    }

    public async void Alterar(Noticia noticia)
    {
        var sql = @"UPDATE TbNoticia SET
                        NotTitulo = @Titulo,
                        NotTexto = @Texto,
                        NotUltimaAtualizacao = @UltimaAtualizacao
                    WHERE NotCodigo = @Id";

        var parametros = new
        {
            noticia.Id,
            noticia.Titulo,
            noticia.Texto,
            noticia.UltimaAtualizacao
        };

        await _connection.ExecuteAsync(sql, parametros);
    }

    public void Excluir(int id)
    {
        var sql = @"DELETE FROM TbNoticia WHERE NotCodigo = @id";

        var parametros = new { id };

        _connection.ExecuteAsync(sql, parametros);
    }

    public async Task<IEnumerable<Noticia>> Get()
    {
        return await _connection.QueryAsync<Noticia>(
            @"SELECT NotCodigo as Id, NotTitulo as Titulo, NotTexto as Texto, NotUltimaAtualizacao as UltimaAtualizacao
              FROM TbNoticia");
    }

    public async Task<Noticia?> GetById(int id)
    {
        var sql = @"SELECT NotCodigo as Id, NotTitulo as Titulo, NotTexto as Texto, NotUltimaAtualizacao as UltimaAtualizacao
                    FROM TbNoticia
                    WHERE NotCodigo = @id";

        var parametros = new { id };

        return await _connection.QueryFirstOrDefaultAsync<Noticia>(sql, parametros);
    }

    public async Task<IEnumerable<Noticia>> GetUltimoMes()
    {
        var sql = @"SELECT NotCodigo as Id, NotTitulo as Titulo, NotTexto as Texto, NotUltimaAtualizacao as UltimaAtualizacao
                    FROM TbNoticia
                    WHERE NotUltimaAtualizacao >= @DataFiltro";

        var parametros = new { DataFiltro = DateTime.Now.AddMonths(-1) };

        return await _connection.QueryAsync<Noticia>(sql, parametros);
    }
}