using System.ComponentModel.DataAnnotations;

namespace PrediccionSentiminetoBack.Models
{
    public class Archivo
    {
        [Key]
        public int Id { get; set; }        
        public string? Nombre { get; set; }
        public string Separador { get; set; }
        public string Url { get; set; }
        public int UsuarioId { get; set; }

    }
}
