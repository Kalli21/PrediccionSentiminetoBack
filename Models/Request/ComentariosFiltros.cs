using System.ComponentModel;

namespace PrediccionSentiminetoBack.Models.Request
{
    public class ComentariosFiltros
    {
        [DefaultValue(1)]
        public int pageNumber { get; set; } = 1;
        [DefaultValue(10)]
        public int pageSize { get; set; } = 10;
        public int totalPages { get; set; }
        public int totalItems { get; set; }
        public bool paginacion { get; set; } = false;
        public DateTime? fechaIni { get; set; }
        public DateTime? fechaFin { get; set; }
        public int? idProducto { get; set; }
        public virtual ICollection<int>? categoriasId { get; set; }
        public string? userName { get; set; }
    }
}
