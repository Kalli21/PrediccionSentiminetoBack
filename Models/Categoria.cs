using System.ComponentModel.DataAnnotations;

namespace PrediccionSentiminetoBack.Models
{
    public class Categoria
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? Nombre { get; set;}
        public virtual ICollection<Producto>? Productos { get; set; }
        public string? UserName { get; set; }
    }
}
