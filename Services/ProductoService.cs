using Microsoft.AspNetCore.Mvc;
using PrediccionSentiminetoBack.Models.DTO;
using PrediccionSentiminetoBack.Models.Request;
using PrediccionSentiminetoBack.Repository;
using PrediccionSentiminetoBack.Repository.Interfaces;
using PrediccionSentiminetoBack.Services.Interfaces;

namespace PrediccionSentiminetoBack.Services
{
    public class ProductoService : IProductoService
    {
        private readonly IProductoRepository _productoRepository;
        protected ResponseDTO _response;

        public ProductoService(IProductoRepository productoRepository)
        {
            _productoRepository = productoRepository;
            _response = new ResponseDTO();
        }
        public async Task<ActionResult<ProductoDTO>> CreateProducto(ProductoDTO productoDTO)
        {
            try
            {
                ProductoDTO exist = await _productoRepository.ExisteInUser(productoDTO);
                if (exist==null)
                {
                    ProductoDTO model = await _productoRepository.CreateProducto(productoDTO);
                    _response.Result = model;
                    return new CreatedAtActionResult("GetProducto", "Producto", new { id = model.Id }, _response);
                }
                else {
                    _response.IsSuccess = false;
                    _response.Result = exist;
                    _response.DisplayMessage = "El Producto ya existe en el Usuario";
                    return new OkObjectResult(_response);
                }
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.DisplayMessage = "Error al registrar el producto";
                _response.ErrorMessages = new List<string> { ex.ToString() };
                return new BadRequestObjectResult(_response);
            }
        }

        public async Task<IActionResult> DeleteProducto(int id)
        {
            try
            {
                bool eliminado = await _productoRepository.DeleteProducto(id);
                if (eliminado)
                {
                    _response.Result = eliminado;
                    _response.DisplayMessage = "Producto eliminado con exito";
                    return new OkObjectResult(_response);
                }
                else
                {
                    _response.IsSuccess = false;
                    _response.DisplayMessage = "Error al eliminar producto";
                    return new BadRequestObjectResult(_response);
                }
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string> { ex.ToString() };
                return new BadRequestObjectResult(_response);

            }
        }

        public async Task<ActionResult<ProductoDTO>> GetProductoById(int id)
        {
            var producto = await _productoRepository.GetProductoById(id);
            if (producto == null)
            {
                _response.IsSuccess = false;
                _response.DisplayMessage = "El Producto no Existe";
                return new NotFoundObjectResult(_response);

            }
            else
            {
                _response.Result = producto;
                _response.DisplayMessage = "Información del producto";
                return new OkObjectResult(_response);
            }
        }

        public async Task<ActionResult<IEnumerable<ProductoDTO>>> GetProductos()
        {
            try
            {
                var lista = await _productoRepository.GetProductos();
                _response.Result = lista;
                _response.DisplayMessage = "Lista de Productos";
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string> { ex.ToString() };
            }

            return new OkObjectResult(_response);
        }

        public async Task<IActionResult> UpdateProducto(int id, ProductoDTO productoDTO)
        {
            try
            {
                if (id != productoDTO.Id)
                {
                    _response.DisplayMessage = "El id no coincide";
                    return new BadRequestObjectResult(_response);
                }
                ProductoDTO model = await _productoRepository.UpdateProducto(productoDTO);
                _response.Result = model;
                return new OkObjectResult(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.DisplayMessage = "Error al actualizar el producto";
                _response.ErrorMessages = new List<string> { ex.ToString() };
                return new BadRequestObjectResult(_response);
            }
        }

        public async Task<ActionResult<ProductoDTO>> GetProductoByIdByUser(int userid, int id)
        {
            var producto = await _productoRepository.GetProductoByIdByUser(userid,id);
            if (producto == null)
            {
                _response.IsSuccess = false;
                _response.DisplayMessage = "El Producto no Existe";
                return new NotFoundObjectResult(_response);

            }
            else
            {
                _response.Result = producto;
                _response.DisplayMessage = "Información del producto";
                return new OkObjectResult(_response);
            }
        }

        public async Task<ActionResult<IEnumerable<ProductoDTO>>> GetProductosByUser(int userid, ProductosFiltros filtros)
        {
            try
            {
                ICollection<ProductoDTO> lista = await GetProductosByUserByFiltros(userid,filtros);
                _response.Result = lista;
                _response.DisplayMessage = "Lista de Productos del usuario";
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string> { ex.ToString() };
            }

            return new OkObjectResult(_response);
        }

        private async Task<ICollection<ProductoDTO>> GetProductosByUserByFiltros(int userid, ProductosFiltros filtros)
        {
            if (filtros == null || filtros.nombre == null)
            {
                return await _productoRepository.GetProductosByUser(userid);
            }
            
            return await _productoRepository.GetProductosByUserByName(userid,filtros.nombre);
        }
    }
}
