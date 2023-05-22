using AutoMapper;
using PrediccionSentiminetoBack.Models.DTO;
using PrediccionSentiminetoBack.Models;

namespace PrediccionSentiminetoBack.Conf
{
    public class MappingConf
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<CategoriaDTO, Categoria>();
                config.CreateMap<Categoria, CategoriaDTO>();

                config.CreateMap<ClienteDTO, Cliente>();
                config.CreateMap<Cliente, ClienteDTO>();

                config.CreateMap<ComentarioDTO, Comentario>();
                config.CreateMap<Comentario, ComentarioDTO>();

                config.CreateMap<ProductoDTO, Producto>();
                config.CreateMap<Producto, ProductoDTO>();

                config.CreateMap<UsuarioDTO, Usuario>();
                config.CreateMap<Usuario, UsuarioDTO>();

            });
            return mappingConfig;
        }
    }
}
