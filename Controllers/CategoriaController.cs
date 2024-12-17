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
using PrediccionSentiminetoBack.Models.Request;
using PrediccionSentiminetoBack.Services;
using PrediccionSentiminetoBack.Services.Interfaces;

namespace PrediccionSentiminetoBack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CategoriaController : ControllerBase
    {
        private readonly ICategoriaService _categoriaService;

        public CategoriaController(ICategoriaService categoriaService)
        {
            _categoriaService = categoriaService;
        }

        // GET: api/Categoria
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoriaDTO>>> GetCategoria()
        {
            return await _categoriaService.GetCategorias();
        }

        // GET: api/Categoria/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CategoriaDTO>> GetCategoria(int id)
        {
            return await _categoriaService.GetCategoriaById(id);
        }

        // PUT: api/Categoria/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCategoria(int id, CategoriaDTO categoriaDTO)
        {
            return await _categoriaService.UpdateCategoria(id, categoriaDTO);
        }

        // POST: api/Categoria
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CategoriaDTO>> PostCategoria(CategoriaDTO categoriaDTO)
        {
            return await _categoriaService.CreateCategoria(categoriaDTO);
        }

        // DELETE: api/Categoria/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategoria(int id)
        {
            return await _categoriaService.DeleteCategoria(id);
        }

        // GET: api/Categoria/username
        [HttpGet("username/{username}")]
        public async Task<ActionResult<IEnumerable<CategoriaDTO>>> GetCategoriaByUser(string username)
        {
            return await _categoriaService.GetCategoriasByUser(username);
        }

        // GET: api/Categoria/username/5
        [HttpGet("username/{username}/{id}")]
        public async Task<ActionResult<CategoriaDTO>> GetCategoriaByUserAndId(string username, int id)
        {
            return await _categoriaService.GetCategoriaByIdByUser(username, id);
        }

        // GET: api/Categoria/username/name
        [HttpGet("username/cat/{username}/{name}")]
        public async Task<ActionResult<CategoriaDTO>> GetCategoriaByNameAndId(string username, string name)
        {
            return await _categoriaService.GetCategoriaByNameByUser(username, name);
        }

        // GET: api/Categoria/username
        [HttpPost("username/coment/{username}")]
        public async Task<ActionResult<IEnumerable<CategoriaDTO>>> GetCategoriaByUserConComentarios(string username, CategoriasFiltros? filtros = null)
        {
            return await _categoriaService.GetCategoriasByUserConComentarios(username, filtros);
        }
    }
}
