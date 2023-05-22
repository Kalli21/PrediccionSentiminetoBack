using Microsoft.AspNetCore.Mvc;
using PrediccionSentiminetoBack.Models.DTO;

namespace PrediccionSentiminetoBack.Services.Interfaces
{
    public interface IProductoService
    {
        Task<ActionResult<IEnumerable<ProductoDTO>>> GetProductos();
        Task<ActionResult<ProductoDTO>> GetProductoById(int id);
        Task<ActionResult<ProductoDTO>> CreateProducto(ProductoDTO productoDTO);
        Task<IActionResult> UpdateProducto(int id, ProductoDTO productoDTO);
        Task<IActionResult> DeleteProducto(int id);
    }
}
