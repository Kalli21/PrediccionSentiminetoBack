using System.ComponentModel;

namespace PrediccionSentiminetoBack.Models.DTO
{
    public class ComentarioDTO
    {

        public int Id { get; set; }
        public string? Contenido { get; set; }
        public DateTime? Fecha { get; set; }
        public int ProductoId { get; set; }
        [DefaultValue(1)]
        public int Estado { get; set; } = 1;
        public int ClienteId { get; set; }
        public string? UserName { get; set; }
        public string? CategoriaNombre { get; set; }
        public string? IdCategoria { get; set; }

    }

    public class RelacionComCatDTO
    {
        public int IdComentario { get; set; }
        public int IdCategoria { get; set; }
        public string? CodMes { get; set; }
        public string? NombreCategoria { get; set; }
        public string? NombreProducto { get; set; }
        public string? CodCliente { get; set; }
        
    }   


}
