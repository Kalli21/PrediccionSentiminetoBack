using Microsoft.AspNetCore.Mvc;
using PrediccionSentiminetoBack.Models.DTO;
using PrediccionSentiminetoBack.Models.Request;

namespace PrediccionSentiminetoBack.Services.Interfaces
{
    public interface IProductoService
    {
        Task<ActionResult<IEnumerable<ProductoDTO>>> GetProductos();
        Task<ActionResult<ProductoDTO>> GetProductoById(int id);
        Task<ActionResult<ProductoDTO>> CreateProducto(ProductoDTO productoDTO);
        Task<IActionResult> UpdateProducto(int id, ProductoDTO productoDTO);
        Task<IActionResult> DeleteProducto(int id);
        Task<ActionResult<IEnumerable<ProductoDTO>>> GetProductosByUser(int userid, ProductosFiltros filtros);
        Task<ActionResult<ProductoDTO>> GetProductoByIdByUser(int userid, int id);
        Task<ActionResult<ProductoDTO>> AddCategoriaInProductoById(int idProd, int idCat);
    }
}
