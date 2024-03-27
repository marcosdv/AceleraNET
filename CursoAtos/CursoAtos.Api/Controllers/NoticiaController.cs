using CursoAtos.Domain.Commands.Interfaces;
using CursoAtos.Domain.Commands.Noticia;
using CursoAtos.Domain.Handlers;
using CursoAtos.Domain.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CursoAtos.Api.Controllers;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class NoticiaController : ControllerBase
{
    private readonly NoticiaHandler _handler;
    private readonly INoticiaRepository _repository;

    public NoticiaController(NoticiaHandler handler, INoticiaRepository repository)
    {
        _handler = handler;
        _repository = repository;
    }

    [HttpPost]
    public ICommandsResult Inserir(NoticiaInserirCommand command)
    {
        return _handler.Handle(command);
    }

    [HttpPut]
    public ICommandsResult Alterar(NoticiaAlterarCommand command)
    {
        return _handler.Handle(command);
    }

    [HttpDelete]
    public ICommandsResult Excluir(NoticiaExcluirCommand command)
    {
        return _handler.Handle(command);
    }

    [HttpGet]
    public IActionResult Get()
    {
        return Ok(_repository.Get());
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        return Ok(_repository.GetById(id));
    }

    [AllowAnonymous]
    [HttpGet("UltimoMes")]
    public IActionResult GetUltimasNoticias()
    {
        return Ok(_repository.GetUltimoMes());
    }
}