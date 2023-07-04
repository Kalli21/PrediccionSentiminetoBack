namespace PrediccionSentiminetoBack.Models.Request
{
    public class CategoriasFiltros
    {
        public DateTime? fechaIni { get; set; }
        public DateTime? fechaFin { get; set; }
        public virtual ICollection<int>? categoriasId { get; set; }
    }
}
