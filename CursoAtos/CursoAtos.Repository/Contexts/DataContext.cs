using CursoAtos.Domain.Entities;
using CursoAtos.Repository.Mappings;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace CursoAtos.Repository.Contexts;

[ExcludeFromCodeCoverage]
public class DataContext : DbContext
{
    public DataContext() { }

    public DataContext(DbContextOptions<DataContext> opt) : base(opt) { }

    public DbSet<Noticia> Noticias { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfiguration(new NoticiaMap());

        /*
        modelBuilder.Entity<Noticia>(x => x.ToSqlQuery("SELECT * FROM TbNoticia"));
        */
    }
}