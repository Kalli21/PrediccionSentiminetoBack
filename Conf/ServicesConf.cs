using PrediccionSentiminetoBack.Services.Interfaces;
using PrediccionSentiminetoBack.Services;

namespace PrediccionSentiminetoBack.Conf
{
    public class ServicesConf
    {
        public static void add(WebApplicationBuilder builder)
        {
            builder.Services.AddScoped<ICategoriaService, CategoriaService>();
            builder.Services.AddScoped<IClienteService, ClienteService>();
            builder.Services.AddScoped<IComentarioService, ComentarioService>();
            builder.Services.AddScoped<IProductoService, ProductoService>();
            builder.Services.AddScoped<IUsuarioService, UsuarioService>();
            builder.Services.AddScoped<IArchivoService, ArchivoService>();

        }
    }
}
