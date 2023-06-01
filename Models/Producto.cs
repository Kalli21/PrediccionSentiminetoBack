using System.ComponentModel.DataAnnotations;

namespace PrediccionSentiminetoBack.Models
{
    public class Producto
    {
        [Key]
        public int Id { get; set; }
        public string? CodProduct { get; set; }
        public string? Nombre { get; set; }
        public string? Descripcion { get; set;}
        public float Precio { get; set; }
        public string? UrlImg { get; set; }
        public int UsuarioId { get; set; }
        public int CategoriaId { get; set; }
        public virtual ICollection<Comentario>? Comentarios { get; set; }
    }
}
