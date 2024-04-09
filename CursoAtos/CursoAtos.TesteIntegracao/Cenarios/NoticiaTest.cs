using CursoAtos.Domain.Commands.Noticia;
using CursoAtos.Domain.Commands.Results;
using CursoAtos.TesteIntegracao.Helpers;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http.Headers;
using System.Text;

namespace CursoAtos.TesteIntegracao.Cenarios;

public class NoticiaTest : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly WebApplicationFactory<Program> _factory;
    private readonly ClienteHttpToken _clienteHttpToken;

    public NoticiaTest(WebApplicationFactory<Program> factory)
    {
        _factory = factory;
        _clienteHttpToken = new ClienteHttpToken(_factory);
    }

    [Fact]
    public async void Get_NoticiasUltimoMesDeveRetornarSucesso()
    {
        var clienteHttp = _factory.CreateClient();

        var response = await clienteHttp.GetAsync("api/Noticia/UltimoMes");

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }

    [Theory]
    [InlineData("api/Noticia")]
    [InlineData("api/Noticia/1")]
    public async void Get_NoticiasSemTokenDeveRetornarUnauthorized(string url)
    {
        var clienteHttp = _factory.CreateClient();

        var response = await clienteHttp.GetAsync(url);

        Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);
    }

    [Theory]
    [InlineData("api/Noticia")]
    [InlineData("api/Noticia/1")]
    public async void Get_NoticiasComTokenDeveRetornarSucesso(string url)
    {
        var clienteHttp = _clienteHttpToken.criar();

        var response = await clienteHttp.GetAsync(url);

        //Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        response.EnsureSuccessStatusCode(); //Comparar com todos os status code validos de sucesso: 200 - 299
    }

    [Fact]
    public async void Post_NoticiaSemTokenDeveRetornarUnauthorized()
    {
        var clienteHttp = _factory.CreateClient();

        var response = await clienteHttp.PostAsync("api/Noticia", null);

        Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);
    }

    [Fact]
    public async void Post_NoticiaComTokenDeveRetornarSucesso()
    {
        var clienteHttp = _clienteHttpToken.criar();

        var command = new NoticiaInserirCommand("", "Descrição do Teste Integração");

        var jsonContent = JsonConvert.SerializeObject(command);
        var contentString = new StringContent(jsonContent, Encoding.UTF8, "application/json");
        contentString.Headers.ContentType = new MediaTypeHeaderValue("application/json");

        var response = await clienteHttp.PostAsync("api/Noticia", contentString);

        response.EnsureSuccessStatusCode(); //Comparar com todos os status code validos de sucesso: 200 - 299

        var responseData = await response.Content.ReadAsStringAsync();
        var resultData = JsonConvert.DeserializeObject<CommandsResults>(responseData);
        Assert.False(resultData.Sucesso);
    }

    [Fact]
    public async void Put_NoticiaSemTokenDeveRetornarUnauthorized()
    {
        var clienteHttp = _factory.CreateClient();

        var response = await clienteHttp.PutAsync("api/Noticia", null);

        Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);
    }

    [Fact]
    public async void Put_NoticiaComTokenDeveRetornarSucesso()
    {
        var clienteHttp = _clienteHttpToken.criar();

        var command = new NoticiaAlterarCommand(0, "", "Descrição do Teste Integração");

        var jsonContent = JsonConvert.SerializeObject(command);
        var contentString = new StringContent(jsonContent, Encoding.UTF8, "application/json");
        contentString.Headers.ContentType = new MediaTypeHeaderValue("application/json");

        var response = await clienteHttp.PutAsync("api/Noticia", contentString);

        response.EnsureSuccessStatusCode(); //Comparar com todos os status code validos de sucesso: 200 - 299

        var responseData = await response.Content.ReadAsStringAsync();
        var resultData = JsonConvert.DeserializeObject<CommandsResults>(responseData);
        Assert.False(resultData.Sucesso);
    }
}