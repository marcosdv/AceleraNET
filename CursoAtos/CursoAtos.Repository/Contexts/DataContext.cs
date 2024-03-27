using CursoAtos.Domain.Entities;
using CursoAtos.Repository.Mappings;
using Microsoft.EntityFrameworkCore;

namespace CursoAtos.Repository.Contexts;

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