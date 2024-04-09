using CursoAtosDapper.Models;
using CursoAtosDapper.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace CursoAtosDapper.Controllers;

[Route("api/[controller]")]
[ApiController]
public class NoticiaController : ControllerBase
{
    private readonly NoticiaRepositoryAdoNet _repository;

    public NoticiaController()
    {
        _repository = new NoticiaRepositoryAdoNet();
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var lista = await _repository.Get();

        return Ok(lista);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var noticia = await _repository.GetById(id);

        return Ok(noticia);
    }

    [HttpGet("UltimoMes")]
    public async Task<IActionResult> GetUltimoMes()
    {
        var lista = await _repository.GetUltimoMes();

        return Ok(lista);
    }

    [HttpPost]
    public IActionResult Inserir(Noticia noticia)
    {
        if (noticia.Titulo.IsNullOrEmpty())
        {
            return BadRequest("Campo título deve ser preenchido!");
        }

        _repository.Inserir(noticia);

        return Ok("Notícia inserida com sucesso!");
    }

    [HttpPut]
    public IActionResult Alterar(Noticia noticia)
    {
        if (noticia.Id <= 0)
        {
            return BadRequest("Campo ID deve ser preenchido!");
        }
        if (noticia.Titulo.IsNullOrEmpty())
        {
            return BadRequest("Campo título deve ser preenchido!");
        }

        _repository.Alterar(noticia);

        return Ok("Notícia alterada com sucesso!");
    }

    [HttpDelete("{id}")]
    public IActionResult Excluir(int id)
    {
        if (id <= 0)
        {
            return BadRequest("Campo ID deve ser preenchido!");
        }
        
        _repository.Excluir(id);

        return Ok("Notícia excluida com sucesso!");
    }
}