using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using System.Net.Http.Headers;

namespace CursoAtos.TesteIntegracao.Helpers;

public class ClienteHttpToken
{
    private readonly WebApplicationFactory<Program> _factory;

    public ClienteHttpToken(WebApplicationFactory<Program> factory)
    {
        _factory = factory;
    }

    public HttpClient? criar()
    {
        var clienteHttp = _factory.WithWebHostBuilder(builder =>
        {
            builder.ConfigureTestServices(services =>
            {
                services.AddAuthentication(defaultScheme: "TestScheme")
                    .AddScheme<AuthenticationSchemeOptions, AuthTestHandler>("TestScheme", opt => { });
            });
        })
        .CreateClient(new WebApplicationFactoryClientOptions { AllowAutoRedirect = false });

        clienteHttp.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(scheme: "TestScheme");

        return clienteHttp;
    }
}