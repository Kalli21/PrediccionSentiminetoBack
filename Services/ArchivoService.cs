using Microsoft.AspNetCore.Mvc;
using PrediccionSentiminetoBack.Models.DTO;
using PrediccionSentiminetoBack.Repository.Interfaces;
using PrediccionSentiminetoBack.Services.Interfaces;

namespace PrediccionSentiminetoBack.Services
{
    public class ArchivoService : IArchivoService
    {
        private readonly IArchivoRepository _ArchivoRepository;
        protected ResponseDTO _response;

        public ArchivoService(IArchivoRepository ArchivoRepository)
        {
            _ArchivoRepository = ArchivoRepository;
            _response = new ResponseDTO();
        }
        public async Task<ActionResult<ArchivoDTO>> CreateArchivo(ArchivoDTO archivoDTO)
        {
            try
            {
                ArchivoDTO model = await _ArchivoRepository.CreateArchivo(archivoDTO);
                _response.Result = model;
                return new CreatedAtActionResult("GetArchivo", "Archivo", new { id = model.Id }, _response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.DisplayMessage = "Error al registrar el archivo";
                _response.ErrorMessages = new List<string> { ex.ToString() };
                return new BadRequestObjectResult(_response);
            }
        }

        public async Task<IActionResult> DeleteArchivo(int id)
        {
            try
            {
                bool eliminado = await _ArchivoRepository.DeleteArchivo(id);
                if (eliminado)
                {
                    _response.Result = eliminado;
                    _response.DisplayMessage = "Archivo eliminada con exito";
                    return new OkObjectResult(_response);
                }
                else
                {
                    _response.IsSuccess = false;
                    _response.DisplayMessage = "Error al eliminar archivo";
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

        public async Task<ActionResult<ArchivoDTO>> GetArchivoById(int id)
        {
            var archivo = await _ArchivoRepository.GetArchivoById(id);
            if (archivo == null)
            {
                _response.IsSuccess = false;
                _response.DisplayMessage = "La Archivo no Existe";
                return new NotFoundObjectResult(_response);

            }
            else
            {
                _response.Result = archivo;
                _response.DisplayMessage = "Información de la archivo";
                return new OkObjectResult(_response);
            }
        }

        public async Task<ActionResult<IEnumerable<ArchivoDTO>>> GetArchivos()
        {
            try
            {
                var lista = await _ArchivoRepository.GetArchivos();
                _response.Result = lista;
                _response.DisplayMessage = "Lista de Archivos";
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string> { ex.ToString() };
            }

            return new OkObjectResult(_response);
        }

        public async Task<IActionResult> UpdateArchivo(int id, ArchivoDTO archivoDTO)
        {
            try
            {
                if (id != archivoDTO.Id)
                {
                    _response.DisplayMessage = "El id no coincide";
                    return new BadRequestObjectResult(_response);
                }
                ArchivoDTO model = await _ArchivoRepository.UpdateArchivo(archivoDTO);
                _response.Result = model;
                return new OkObjectResult(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.DisplayMessage = "Error al actualizar el archivo";
                _response.ErrorMessages = new List<string> { ex.ToString() };
                return new BadRequestObjectResult(_response);
            }
        }
    }
}
