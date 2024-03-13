using CursoAtos.Domain.Repositories;
using CursoAtos.Domain.Requests;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Text;

namespace CursoAtos.Domain.Services;

public class LoginService
{
    private readonly IConfiguration _config;
    private readonly IUsuarioRepository _repository;

    public LoginService(IConfiguration config, IUsuarioRepository repository)
    {
        _config = config;
        _repository = repository;
    }

    public string VerificarUsuario(LoginRequest request)
    {
        var result = _repository.Login(request);

        if (result != null)
        {
            return GerarToken();
        }

        return string.Empty;
    }

    private string GerarToken()
    {
        var validade = DateTime.Now.AddHours(1);

        var issuer = _config["Jwt:Issuer"];
        var audience = _config["Jwt:Audience"];
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"] ?? ""));
        var credenciais = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(issuer, audience, expires: validade, signingCredentials: credenciais);

        var tokenHandler = new JwtSecurityTokenHandler();

        return tokenHandler.WriteToken(token);
    }
}