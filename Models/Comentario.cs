using System.ComponentModel.DataAnnotations;

namespace PrediccionSentiminetoBack.Models
{
    public class Comentario
    {
        [Key]
        public int Id { get; set; }
        public string? Contenido { get; set; }
        public DateTime? Fecha { get; set;}
        public int ProductoId { get; set; }
        public int ClienteId { get; set; }
        public string? UserName { get; set; }


    }
}
