using CursoAtos.Domain.Repositories;
using CursoAtos.Domain.Requests;
using CursoAtos.Domain.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CursoAtos.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LoginController : ControllerBase
{
    private readonly LoginService _service;
    private readonly IUsuarioRepository _repository;

    public LoginController(LoginService service, IUsuarioRepository repository)
    {
        _service = service;
        _repository = repository;
    }

    [HttpPost]
    public IActionResult Login(LoginRequest request)
    {
        var result = _service.VerificarUsuario(request);
        
        if (string.IsNullOrEmpty(result))
        {
            return Unauthorized();
        }

        return Ok(result);
    }

    [Authorize]
    [HttpGet]
    public IActionResult GetUsuario(int id)
    {
        var result = _repository.GetById(id);

        return Ok(result);
    }
}