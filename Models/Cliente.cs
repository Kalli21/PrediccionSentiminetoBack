using System.ComponentModel.DataAnnotations;

namespace PrediccionSentiminetoBack.Models
{
    public class Cliente
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? Nombre { get; set; }
        public string CodCliente { get; set; }
        public virtual ICollection<Comentario>? Comentarios { get; set; }
        public string UserName { get; set; }
    }
}
