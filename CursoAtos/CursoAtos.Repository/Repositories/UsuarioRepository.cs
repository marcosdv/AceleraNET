using CursoAtos.Domain.Entities;
using CursoAtos.Domain.Repositories;
using CursoAtos.Domain.Requests;

namespace CursoAtos.Repository.Repositories;

public class UsuarioRepository : IUsuarioRepository
{
    public void Inserir(Usuario usuario)
    {
        throw new NotImplementedException();
    }

    public void Alterar(Usuario usuario)
    {
        throw new NotImplementedException();
    }

    public void Excluir(int id)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Usuario> Get()
    {
        throw new NotImplementedException();
    }

    public Usuario? GetById(int id)
    {
        if (id == 1)
        {
            return new Usuario
            {
                Id = id,
                Nome = "Usuário ADM",
                Login = "admin",
                Senha = "admin"
            };
        }

        return null;
    }

    public Usuario? Login(LoginRequest request)
    {
        if (request.Usuario == "admin" && request.Senha == "admin")
        {
            return GetById(1);
        }

        return null;
    }
}