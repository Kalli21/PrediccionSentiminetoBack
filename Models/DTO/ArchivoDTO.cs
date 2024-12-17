namespace PrediccionSentiminetoBack.Models.DTO
{
    public class ArchivoDTO
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public string Url { get; set; }
        public string Separador { get; set; }
        public int UsuarioId { get; set; }
    }
}
