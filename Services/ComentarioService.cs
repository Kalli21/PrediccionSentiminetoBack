using Microsoft.AspNetCore.Mvc;
using PrediccionSentiminetoBack.Models.DTO;
using PrediccionSentiminetoBack.Repository;
using PrediccionSentiminetoBack.Repository.Interfaces;
using PrediccionSentiminetoBack.Services.Interfaces;

namespace PrediccionSentiminetoBack.Services
{
        public class ComentarioService : IComentarioService
    {
        private readonly IComentarioRepository _comentarioRepository;
        protected ResponseDTO _response;

        public ComentarioService(IComentarioRepository comentarioRepository)
        {
            _comentarioRepository = comentarioRepository;
            _response = new ResponseDTO();
        }
        public async Task<ActionResult<ComentarioDTO>> CreateComentario(ComentarioDTO comentarioDTO)
        {
            try
            {
                ComentarioDTO model = await _comentarioRepository.CreateComentario(comentarioDTO);
                _response.Result = model;
                return new CreatedAtActionResult("GetComentario", "Comentario", new { id = model.Id }, model);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.DisplayMessage = "Error al registrar el categoria";
                _response.ErrorMessages = new List<string> { ex.ToString() };
                return new BadRequestObjectResult(_response);
            }
        }

        public async Task<IActionResult> DeleteComentario(int id)
        {
            try
            {
                bool eliminado = await _comentarioRepository.DeleteComentario(id);
                if (eliminado)
                {
                    _response.Result = eliminado;
                    _response.DisplayMessage = "Comentario eliminada con exito";
                    return new OkObjectResult(_response);
                }
                else
                {
                    _response.IsSuccess = false;
                    _response.DisplayMessage = "Error al eliminar categoria";
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

        public async Task<ActionResult<ComentarioDTO>> GetComentarioById(int id)
        {
            var categoria = await _comentarioRepository.GetComentarioById(id);
            if (categoria == null)
            {
                _response.IsSuccess = false;
                _response.DisplayMessage = "La Comentario no Existe";
                return new NotFoundObjectResult(_response);

            }
            else
            {
                _response.Result = categoria;
                _response.DisplayMessage = "Información de la categoria";
                return new OkObjectResult(_response);
            }
        }

        public async Task<ActionResult<IEnumerable<ComentarioDTO>>> GetComentarios()
        {
            try
            {
                var lista = await _comentarioRepository.GetComentarios();
                _response.Result = lista;
                _response.DisplayMessage = "Lista de Comentarios";
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string> { ex.ToString() };
            }

            return new OkObjectResult(_response);
        }

        public async Task<IActionResult> UpdateComentario(int id, ComentarioDTO comentarioDTO)
        {
            try
            {
                if (id != comentarioDTO.Id)
                {
                    _response.DisplayMessage = "El id no coincide";
                    return new BadRequestObjectResult(_response);
                }
                ComentarioDTO model = await _comentarioRepository.UpdateComentario(comentarioDTO);
                _response.Result = model;
                return new OkObjectResult(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.DisplayMessage = "Error al actualizar el categoria";
                _response.ErrorMessages = new List<string> { ex.ToString() };
                return new BadRequestObjectResult(_response);
            }
        }
    }
}

