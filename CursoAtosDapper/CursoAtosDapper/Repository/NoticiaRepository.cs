using CursoAtosDapper.Models;
using CursoAtosDapper.Repository.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.Win32.SafeHandles;
using System.Data;

namespace CursoAtosDapper.Repository;

public class NoticiaRepository : INoticiaRepository
{
    public void Inserir(Noticia noticia)
    {
        throw new NotImplementedException();
    }

    public void Alterar(Noticia noticia)
    {
        throw new NotImplementedException();
    }

    public void Excluir(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<Noticia>> Get()
    {
        var connectionString = "Server=MDV-NOTE;Database=AulaCurso;Trusted_Connection=True;Integrated Security=true;Encrypt=False;";
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

                while(reader.Read())
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

    public Noticia? GetById(int id)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Noticia> GetUltimoMes()
    {
        throw new NotImplementedException();
    }
}