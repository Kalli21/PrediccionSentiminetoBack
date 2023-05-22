using PrediccionSentiminetoBack.Repository.Interfaces;
using PrediccionSentiminetoBack.Repository;

namespace PrediccionSentiminetoBack.Conf
{
    public class RepositoriesConf
    {
        public static void add(WebApplicationBuilder builder)
        {
            builder.Services.AddScoped<ICategoriaRepository, CategoriaRepository>();
            builder.Services.AddScoped<IClienteRepository, ClienteRepository>();
            builder.Services.AddScoped<IComentarioRepository, ComentarioRepository>();
            builder.Services.AddScoped<IProductoRepository, ProductoRepository>();
            builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();

        }
    }
}

