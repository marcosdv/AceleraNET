using CursoAtos.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Diagnostics.CodeAnalysis;

namespace CursoAtos.Repository.Mappings;

[ExcludeFromCodeCoverage]
public class NoticiaMap : IEntityTypeConfiguration<Noticia>
{
    public void Configure(EntityTypeBuilder<Noticia> builder)
    {
        //Indicando qual o nome da tabela no banco de dados.
        builder.ToTable("TbNoticia");

        //Informar qual a chave primaria da tabela
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)     //Selecionando o item ID da classe
            .HasColumnName("NotCodigo") //Informando o nome do campo real do banco de dados
            .ValueGeneratedOnAdd()      //Gerar um novo valor automaticamente a cada novo objeto
            .UseIdentityColumn();       //Especifica que a coluna é uma identidade que vai ser somada de 1 a 1

        builder.Property(x => x.Titulo) //Selecionando o item Itulo da classe
            .HasColumnName("NotTitulo") //Informando o nome do campo real do banco de dados
            .IsRequired()               //Informando que o campo é NotNull no banco de dados
            .HasColumnType("varchar")   //Definindo o tipo do campo como VARCHAR
            .HasMaxLength(50);          //Definindo o tamanho do varchar para 50 -> varchar(50)

        builder.Property(x => x.Texto)
            .HasColumnName("NotTexto")
            .HasColumnType("text");

        builder.Property(x => x.UltimaAtualizacao)
            .HasColumnName("NotUltimaAtualizacao")
            .HasColumnType("datetime")
            .IsRequired();
    }
}