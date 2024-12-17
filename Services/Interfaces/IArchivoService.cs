using Microsoft.AspNetCore.Mvc;
using PrediccionSentiminetoBack.Models.DTO;

namespace PrediccionSentiminetoBack.Services.Interfaces
{
    public interface IArchivoService
    {
        Task<ActionResult<IEnumerable<ArchivoDTO>>> GetArchivos();
        Task<ActionResult<ArchivoDTO>> GetArchivoById(int id);
        Task<ActionResult<ArchivoDTO>> CreateArchivo(ArchivoDTO archivoDTO);
        Task<IActionResult> UpdateArchivo(int id, ArchivoDTO archivoDTO);
        Task<IActionResult> DeleteArchivo(int id);
    }
}
