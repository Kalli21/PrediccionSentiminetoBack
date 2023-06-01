namespace PrediccionSentiminetoBack.Models.DTO
{
    public class UsuarioDTO
    {
        public string? UserName { get; set; }
        public string? Nombres { get; set; }
        public string? Correo { get; set; }
        public string? Password { get; set; }
        public string? Token { get; set; }
        public bool activo { get; set; }
        public virtual ICollection<Producto> ?Productos { get; set; }
    }
}
