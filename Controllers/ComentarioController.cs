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
    public class ComentarioController : ControllerBase
    {
        private readonly IComentarioService _comentarioService;

        public ComentarioController(IComentarioService comentarioService)
        {
            _comentarioService = comentarioService;
        }

        // GET: api/Comentarios
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ComentarioDTO>>> GetComentario()
        {
            return await _comentarioService.GetComentarios();
        }

        // GET: api/Comentarios/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ComentarioDTO>> GetComentario(int id)
        {
            return await _comentarioService.GetComentarioById(id);
        }

        // PUT: api/Comentarios/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutComentario(int id, ComentarioDTO comentarioDTO)
        {

            return await _comentarioService.UpdateComentario(id, comentarioDTO);
        }

        // POST: api/Comentarios
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ComentarioDTO>> PostComentario(ComentarioDTO comentarioDTO)
        {
            return await _comentarioService.CreateComentario(comentarioDTO);
        }

        // DELETE: api/Comentarios/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteComentario(int id)
        {
            return await _comentarioService.DeleteComentario(id);
        }

        // GET: api/Comentario/username
        [HttpPost("username/{username}")]
        public async Task<ActionResult<IEnumerable<ComentarioDTO>>> GetComentariosByUser(string username,ComentariosFiltros filtros)
        {
            return await _comentarioService.GetComentariosByUser(username, filtros);
        }

        // GET: api/Comentario/cant/username
        [HttpPost("username/cant/{username}")]
        public async Task<ActionResult<int>> GetCantComentariosByUser(string username)
        {
            return await _comentarioService.GetCantComentariosByUser(username);
        }


        // GET: api/Comentario/username/5
        [HttpGet("username/{username}/{id}")]
        public async Task<ActionResult<ComentarioDTO>> GetComentarioByIdByUser(string username, int id)
        {
            return await _comentarioService.GetComentarioByIdByUser(username, id);
        }

        // GET: api/Comentarios con paginación
        [HttpGet("username/pagina/{username}")]
        public async Task<ActionResult<IEnumerable<ComentarioDTO>>> GetComentariosByuserByPaginacion(string username,int page = 1, int pageSize = 10)
        {
            return await _comentarioService.GetComentariosByuserByPaginacion(username, page, pageSize );
        }
        
        // GET: api/Comentario/username
        [HttpPost("username")]
        public async Task<ActionResult<IEnumerable<ComentarioDTO>>> GetComentariosReducidoConCategorias(ComentariosFiltros filtros)
        {
            return await _comentarioService.GetComentariosReducidoConCategorias(filtros);
        }

    }
}
