using Microsoft.AspNetCore.Mvc;
using PrediccionSentiminetoBack.Models.DTO;
using PrediccionSentiminetoBack.Models.Request;

namespace PrediccionSentiminetoBack.Services.Interfaces
{
    public interface ICategoriaService
    {
        Task<ActionResult<IEnumerable<CategoriaDTO>>> GetCategorias();
        Task<ActionResult<CategoriaDTO>> GetCategoriaById(int id);
        Task<ActionResult<CategoriaDTO>> CreateCategoria(CategoriaDTO categoriaDTO);
        Task<IActionResult> UpdateCategoria(int id, CategoriaDTO categoriaDTO);
        Task<IActionResult> DeleteCategoria(int id);
        Task<ActionResult<IEnumerable<CategoriaDTO>>> GetCategoriasByUser(string username);
        Task<ActionResult<CategoriaDTO>> GetCategoriaByIdByUser(string usernamem,int id);
        Task<ActionResult<CategoriaDTO>> GetCategoriaByNameByUser(string usernamem, string name);
        Task<ActionResult<IEnumerable<CategoriaDTO>>> GetCategoriasByUserConComentarios(string username, CategoriasFiltros? filtros);
    }
}
