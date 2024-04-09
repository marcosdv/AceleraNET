using CursoAtosDapper.Repository;
using Microsoft.AspNetCore.Mvc;

namespace CursoAtosDapper.Controllers;

[Route("api/[controller]")]
[ApiController]
public class NoticiaController
{
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var repository = new NoticiaRepository();
        var lista = await repository.Get();

        return new OkObjectResult(lista);
    }
}