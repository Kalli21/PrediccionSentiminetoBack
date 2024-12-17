using Microsoft.AspNetCore.Mvc;
using PrediccionSentiminetoBack.Models.DTO;
using PrediccionSentiminetoBack.Models.Request;
using System.Drawing.Printing;
using System.Threading.Tasks;

namespace PrediccionSentiminetoBack.Services.Interfaces
{
    public interface IComentarioService
    {
        Task<ActionResult<IEnumerable<ComentarioDTO>>> GetComentarios();
        Task<ActionResult<ComentarioDTO>> GetComentarioById(int id);
        Task<ActionResult<ComentarioDTO>> CreateComentario(ComentarioDTO comentarioDTO);
        Task<IActionResult> UpdateComentario(int id, ComentarioDTO comentarioDTO);
        Task<IActionResult> DeleteComentario(int id);
        Task<ActionResult<IEnumerable<ComentarioDTO>>> GetComentariosByUser(string username, ComentariosFiltros? filtros);
        Task<ActionResult<int>> GetCantComentariosByUser(string username);
        Task<ActionResult<ComentarioDTO>> GetComentarioByIdByUser(string username, int id);
        Task<ActionResult<IEnumerable<ComentarioDTO>>> GetComentariosByuserByPaginacion(string username, int page, int pageSize);

        Task<ActionResult<IEnumerable<ComentarioDTO>>> GetComentariosReducidoConCategorias(ComentariosFiltros? filtros);
    }
}
