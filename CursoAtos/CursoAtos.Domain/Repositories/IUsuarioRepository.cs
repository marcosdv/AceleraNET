using CursoAtos.Domain.Entities;
using CursoAtos.Domain.Requests;

namespace CursoAtos.Domain.Repositories;

public interface IUsuarioRepository
{
    void Inserir(Usuario usuario);
    void Alterar(Usuario usuario);
    void Excluir(int id);

    IEnumerable<Usuario> Get();
    Usuario? GetById(int id);
    Usuario? Login(LoginRequest request);
}
