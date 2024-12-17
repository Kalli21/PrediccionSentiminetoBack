using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PrediccionSentiminetoBack.Models
{
    public class Comentario
    {
        [Key]
        public int Id { get; set; }
        public string? Contenido { get; set; }
        public DateTime? Fecha { get; set;}

        // Estado = 2 , comentario analisado.
        [DefaultValue(1)]
        public int Estado { get; set; } = 1;
        public int ProductoId { get; set; }
        public int ClienteId { get; set; }
        public string? UserName { get; set; }

        // Relelacinoes
        [ForeignKey("ProductoId")]
        public Producto? Producto { get; set; }
        // Relelacinoes
        [ForeignKey("ClienteId")]
        public Cliente? Cliente { get; set; }
    }
}
