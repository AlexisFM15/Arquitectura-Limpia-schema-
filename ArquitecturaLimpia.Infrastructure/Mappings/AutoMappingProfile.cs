using ArquitecturaLimpia.Domain;
using ArquitecturaLimpia.Domain.DTO;
using AutoMapper;

namespace ArquitecturaLimpia.Infrastructure.Mappings
{
    public class AutoMappingProfile : Profile
    {
        public AutoMappingProfile()
        {
            AllowNullCollections = true;
            CreateMap<Articulo,  ArticuloDTO>().ReverseMap();
            CreateMap<Categoria, CategoriaDTO>().ReverseMap();
        }
    }
}
