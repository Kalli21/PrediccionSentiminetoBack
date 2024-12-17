namespace PrediccionSentiminetoBack.Models.Request
{
    public class ComentariosFiltros
    {
        public DateTime? fechaIni { get; set; }
        public DateTime? fechaFin { get; set; }
        public int? idProducto { get; set; }
        public virtual ICollection<int>? categoriasId { get; set; }
        public string? userName { get; set; }
    }
}
