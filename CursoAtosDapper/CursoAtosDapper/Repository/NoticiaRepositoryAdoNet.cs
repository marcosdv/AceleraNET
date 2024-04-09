using CursoAtosDapper.Models;
using CursoAtosDapper.Repository.Interfaces;
using Microsoft.Data.SqlClient;
using System.Data;

namespace CursoAtosDapper.Repository;

public class NoticiaRepositoryAdoNet : INoticiaRepository
{
    private string connectionString = "Server=MDV-NOTE;Database=AulaCurso;Trusted_Connection=True;Integrated Security=true;Encrypt=False;";

    public void Inserir(Noticia noticia)
    {
        using var connection = new SqlConnection(connectionString);
        connection.Open();

        using var command = new SqlCommand();
        command.Connection = connection;
        command.CommandType = CommandType.Text;
        command.CommandText = @"INSERT INTO TbNoticia (NotTitulo, NotTexto, NotUltimaAtualizacao) 
                                               VALUES (@NotTitulo, @NotTexto, @NotUltimaAtualizacao)";

        command.Parameters.Add("@NotTitulo", SqlDbType.VarChar).Value = noticia.Titulo;
        command.Parameters.Add("@NotTexto", SqlDbType.Text).Value = noticia.Texto;
        command.Parameters.Add("@NotUltimaAtualizacao", SqlDbType.DateTime).Value = noticia.UltimaAtualizacao;

        command.ExecuteNonQueryAsync();
    }

    public void Alterar(Noticia noticia)
    {
        using var connection = new SqlConnection(connectionString);
        connection.Open();

        using var command = new SqlCommand();
        command.Connection = connection;
        command.CommandType = CommandType.Text;
        command.CommandText = @"UPDATE TbNoticia SET
                                    NotTitulo = @NotTitulo,
                                    NotTexto = @NotTexto,
                                    NotUltimaAtualizacao = @NotUltimaAtualizacao
                                WHERE NotCodigo = @NotCodigo";

        command.Parameters.Add("@NotCodigo", SqlDbType.Int).Value = noticia.Id;
        command.Parameters.Add("@NotTitulo", SqlDbType.VarChar).Value = noticia.Titulo;
        command.Parameters.Add("@NotTexto", SqlDbType.Text).Value = noticia.Texto;
        command.Parameters.Add("@NotUltimaAtualizacao", SqlDbType.DateTime).Value = noticia.UltimaAtualizacao;

        command.ExecuteNonQueryAsync();
    }

    public void Excluir(int id)
    {
        using var connection = new SqlConnection(connectionString);
        connection.Open();

        using var command = new SqlCommand();
        command.Connection = connection;
        command.CommandType = CommandType.Text;
        command.CommandText = @"DELETE FROM TbNoticia WHERE NotCodigo = @NotCodigo";

        command.Parameters.Add("@NotCodigo", SqlDbType.Int).Value = id;

        command.ExecuteNonQueryAsync();
    }

    #region | Metodos de Busca - GETs |

    public async Task<IEnumerable<Noticia>> Get()
    {
        var listaNoticia = new List<Noticia>();

        using (var connection = new SqlConnection(connectionString))
        {
            connection.Open();

            using (var command = new SqlCommand())
            {
                command.Connection = connection;
                command.CommandType = CommandType.Text;
                command.CommandText = "SELECT NotCodigo, NotTitulo, NotTexto, NotUltimaAtualizacao FROM TbNoticia";

                var reader = await command.ExecuteReaderAsync();

                while (reader.Read())
                {
                    var noticia = new Noticia();
                    noticia.Id = reader.GetInt32("NotCodigo");
                    noticia.Titulo = reader.GetString("NotTitulo");
                    noticia.Texto = reader.GetString("NotTexto");
                    noticia.UltimaAtualizacao = reader.GetDateTime("NotUltimaAtualizacao");

                    listaNoticia.Add(noticia);
                }
            }
        }

        return listaNoticia;
    }

    public async Task<Noticia?> GetById(int id)
    {
        using (var connection = new SqlConnection(connectionString))
        {
            connection.Open();

            using (var command = new SqlCommand())
            {
                command.Connection = connection;
                command.CommandType = CommandType.Text;
                command.CommandText = @"
                    SELECT NotCodigo, NotTitulo, NotTexto, NotUltimaAtualizacao
                    FROM TbNoticia
                    WHERE NotCodigo = @Codigo";
                command.Parameters.Add("@Codigo", SqlDbType.Int).Value = id;

                var reader = await command.ExecuteReaderAsync();

                while (reader.Read())
                {
                    return new Noticia(reader.GetInt32("NotCodigo"), reader.GetString("NotTitulo"),
                                       reader.GetString("NotTexto"), reader.GetDateTime("NotUltimaAtualizacao"));
                }
            }
        }

        return null;
    }

    public async Task<IEnumerable<Noticia>> GetUltimoMes()
    {
        var listaNoticia = new List<Noticia>();

        using (var connection = new SqlConnection(connectionString))
        {
            connection.Open();

            using (var command = new SqlCommand())
            {
                command.Connection = connection;
                command.CommandType = CommandType.Text;
                command.CommandText = @"
                    SELECT NotCodigo, NotTitulo, NotTexto, NotUltimaAtualizacao
                    FROM TbNoticia
                    WHERE NotUltimaAtualizacao >= @DataFiltro";
                command.Parameters.Add("@DataFiltro", SqlDbType.DateTime).Value = DateTime.Now.AddMonths(-1);

                var reader = await command.ExecuteReaderAsync();

                while (reader.Read())
                {
                    var noticia = new Noticia();
                    noticia.Id = reader.GetInt32("NotCodigo");
                    noticia.Titulo = reader.GetString("NotTitulo");
                    noticia.Texto = reader.GetString("NotTexto");
                    noticia.UltimaAtualizacao = reader.GetDateTime("NotUltimaAtualizacao");

                    listaNoticia.Add(noticia);
                }
            }
        }

        return listaNoticia;
    }

    #endregion
}