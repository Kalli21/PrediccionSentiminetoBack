using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PrediccionSentiminetoBack.Models;
using PrediccionSentiminetoBack.Models.DTO;
using PrediccionSentiminetoBack.Services;
using PrediccionSentiminetoBack.Services.Interfaces;

namespace PrediccionSentiminetoBack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProductoController : ControllerBase
    {
        private readonly IProductoService _productoService;

        public ProductoController(IProductoService productoService)
        {
            _productoService = productoService;
        }

        // GET: api/Producto
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductoDTO>>> GetProducto()
        {
            return await _productoService.GetProductos();
        }

        // GET: api/Producto/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductoDTO>> GetProducto(int id)
        {
            return await _productoService.GetProductoById(id);
        }

        // PUT: api/Producto/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProducto(int id, ProductoDTO productoDTO)
        {
            return await _productoService.UpdateProducto(id, productoDTO);
        }

        // POST: api/Producto
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ProductoDTO>> PostProducto(ProductoDTO productoDTO)
        {
            return await _productoService.CreateProducto(productoDTO);
        }

        // DELETE: api/Producto/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProducto(int id)
        {
            return await _productoService.DeleteProducto(id);
        }

        // GET: api/Producto/username
        [HttpGet("username/{userid}")]
        public async Task<ActionResult<IEnumerable<ProductoDTO>>> GetProductosByUser(int userid)
        {
            return await _productoService.GetProductosByUser(userid);
        }

        // GET: api/Producto/username/5
        [HttpGet("username/{userid}/{id}")]
        public async Task<ActionResult<ProductoDTO>> GetProductoByUserAndId(int userid, int id)
        {   
            return await _productoService.GetProductoByIdByUser(userid, id);
        }

    }
}
