using System.ComponentModel;

namespace PrediccionSentiminetoBack.Models.DTO
{
    public class UsuarioDTO
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string? Nombres { get; set; }
        public string? Correo { get; set; }
        public string? Password { get; set; }
        public string? Token { get; set; }
        public bool activo { get; set; }
        [DefaultValue(1)]
        public int Estado { get; set; } = 1;
        public virtual ICollection<Producto> ?Productos { get; set; }
        public virtual ICollection<Archivo>? Archivos { get; set; }
    }
}
