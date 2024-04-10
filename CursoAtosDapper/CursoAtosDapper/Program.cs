using CursoAtosDapper.Mapper;
using CursoAtosDapper.Repository;
using CursoAtosDapper.Repository.Interfaces;
using Microsoft.Data.SqlClient;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

//Injecao de Dependencias - DI

builder.Services.AddScoped(opt => new SqlConnection(builder.Configuration.GetConnectionString("connectionString")));
builder.Services.AddScoped<INoticiaRepository, NoticiaRepositoryDapper>();

//builder.Services.AddScoped<INoticiaRepository, NoticiaRepositoryAdoNet>();
//Injecao de Dependencias - DI

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Adicionando configuracao do AutoMapper
builder.Services.AddAutoMapper(typeof(AutoMapperProfile));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();