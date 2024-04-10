using AutoMapper;
using CursoAtosDapper.Models;

namespace CursoAtosDapper.Mapper;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<NoticiaDTO, Noticia>()
            .ForMember(x => x.Id, y => y.MapFrom(x => x.NotCodigo))
            .ForMember(x => x.Titulo, y => y.MapFrom(x => x.NotTitulo))
            .ForMember(x => x.Texto, y => y.MapFrom(x => x.NotTexto))
            .ForMember(x => x.UltimaAtualizacao, y => y.MapFrom(x => x.NotUltimaAtualizacao));

        CreateMap<Noticia, NoticiaDTO>()
            .ForMember(x => x.NotCodigo, y => y.MapFrom(x => x.Id))
            .ForMember(x => x.NotTitulo, y => y.MapFrom(x => x.Titulo))
            .ForMember(x => x.NotTexto, y => y.MapFrom(x => x.Texto))
            .ForMember(x => x.NotUltimaAtualizacao, y => y.MapFrom(x => x.UltimaAtualizacao));
    }
}