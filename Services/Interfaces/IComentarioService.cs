using Microsoft.AspNetCore.Mvc;
using PrediccionSentiminetoBack.Models.DTO;

namespace PrediccionSentiminetoBack.Services.Interfaces
{
    public interface IComentarioService
    {
        Task<ActionResult<IEnumerable<ComentarioDTO>>> GetComentarios();
        Task<ActionResult<ComentarioDTO>> GetComentarioById(int id);
        Task<ActionResult<ComentarioDTO>> CreateComentario(ComentarioDTO comentarioDTO);
        Task<IActionResult> UpdateComentario(int id, ComentarioDTO comentarioDTO);
        Task<IActionResult> DeleteComentario(int id);
    }
}
