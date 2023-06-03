namespace PrediccionSentiminetoBack.Models.DTO
{
    public class CategoriaDTO
    {
        
        public int Id { get; set; }       
        public string Nombre { get; set; }
        public virtual ICollection<ProductoDTO>? Productos { get; set; }
        public string UserName { get; set; }
    }
}
