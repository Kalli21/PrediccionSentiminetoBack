using System.ComponentModel.DataAnnotations;

namespace PrediccionSentiminetoBack.Models
{
    public class Cliente
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? Nombre { get; set; }
    }
}
