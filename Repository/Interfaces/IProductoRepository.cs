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
        Task<ProductoDTO> ExisteInUser(ProductoDTO productoDTO);
        Task<ICollection<ProductoDTO>> GetProductosByUser(int userid);
        Task<ProductoDTO> GetProductoByIdByUser(int userid, int id);
    }
}
