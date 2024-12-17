using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PrediccionSentiminetoBack.Models.DTO;
using PrediccionSentiminetoBack.Models.Request;
using PrediccionSentiminetoBack.Services.Interfaces;

namespace PrediccionSentiminetoBack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ArchivoController
    {
        private readonly IArchivoService _ArchivoService;

        public ArchivoController(IArchivoService ArchivoService)
        {
            _ArchivoService = ArchivoService;
        }

        // GET: api/Archivo
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ArchivoDTO>>> GetArchivo()
        {
            return await _ArchivoService.GetArchivos();
        }

        // GET: api/Archivo/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ArchivoDTO>> GetArchivo(int id)
        {
            return await _ArchivoService.GetArchivoById(id);
        }

        // PUT: api/Archivo/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutArchivo(int id, ArchivoDTO archivoDTO)
        {
            return await _ArchivoService.UpdateArchivo(id, archivoDTO);
        }

        // POST: api/Archivo
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ArchivoDTO>> PostArchivo(ArchivoDTO archivoDTO)
        {
            return await _ArchivoService.CreateArchivo(archivoDTO);
        }

        // DELETE: api/Archivo/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteArchivo(int id)
        {
            return await _ArchivoService.DeleteArchivo(id);
        }

    }
}
