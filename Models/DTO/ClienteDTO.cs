namespace PrediccionSentiminetoBack.Models.DTO
{
    public class ClienteDTO
    {

        public int Id { get; set; }      
        public string? Nombre { get; set; }
        public string? CodCliente { get; set; }
        public virtual ICollection<Comentario>? Comentarios { get; set; }
        public string? UserName { get; set; }
    }
}
