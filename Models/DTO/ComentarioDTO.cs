namespace PrediccionSentiminetoBack.Models.DTO
{
    public class ComentarioDTO
    {

        public int Id { get; set; }
        public string? Contenido { get; set; }
        public DateTime Fecha { get; set; }
        public int ProductoId { get; set; }
        public int ClienteId { get; set; }
    }
}
