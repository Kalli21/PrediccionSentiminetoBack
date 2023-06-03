using PrediccionSentiminetoBack.Models.DTO;

namespace PrediccionSentiminetoBack.Repository.Interfaces
{
    public interface IProductoRepository
    {
        Task<ICollection<ProductoDTO>> GetProductos();
        Task<ProductoDTO> GetProductoById(int id);
        Task<ProductoDTO> CreateProducto(ProductoDTO productoDTO);
        Task<ProductoDTO> UpdateProducto(ProductoDTO productoDTO);
        Task<bool> DeleteProducto(int id);
        Task<bool> ExisteInUser(ProductoDTO productoDTO);
    }
}
