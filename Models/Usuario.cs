using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PrediccionSentiminetoBack.Models
{
    public class Usuario
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string UserName { get; set; }

        public string? Nombres { get; set; }

        public string? Correo { get; set; }
        [Required]
        public bool activo { get; set; }
        [Required]
        public byte[]? PasswordHash { get; set; }
        [Required]
        public byte[]? PasswordSalt { get; set; }

        [DefaultValue(1)]
        public int Estado { get; set; } = 1;

        public virtual ICollection<Producto>? Productos { get; set; }
        public virtual ICollection<Archivo>? Archivos { get; set; }
    }
}
