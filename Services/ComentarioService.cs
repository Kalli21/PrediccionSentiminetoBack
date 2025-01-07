using Microsoft.AspNetCore.Mvc;
using PrediccionSentiminetoBack.Models.DTO;
using PrediccionSentiminetoBack.Models.Request;
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
                return new CreatedAtActionResult("GetComentario", "Comentario", new { id = model.Id }, _response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.DisplayMessage = "Error al registrar el categoria";
                _response.ErrorMessages = new List<string> { ex.ToString() };
                return new OkObjectResult(_response);
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
                    _response.DisplayMessage = "Comentario eliminado con exito";
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
                _response.DisplayMessage = "El Comentario no Existe";
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
        public async Task<ActionResult<ComentarioDTO>> GetComentarioByIdByUser(string username, int id)
        {
            var categoria = await _comentarioRepository.GetComentarioByIdByUser(username,id);
            if (categoria == null)
            {
                _response.IsSuccess = false;
                _response.DisplayMessage = "El Comentario no Existe en el usuario";
                return new NotFoundObjectResult(_response);

            }
            else
            {
                _response.Result = categoria;
                _response.DisplayMessage = "Información del comentario";
                return new OkObjectResult(_response);
            }
        }

        public async Task<ActionResult<IEnumerable<ComentarioDTO>>> GetComentariosByUser(string username,ComentariosFiltros? filtros)
        {
            try
            {
                ICollection<ComentarioDTO> lista = await GetComentariosByuserByFiltro(username, filtros);
                _response.Result = lista;
                _response.DisplayMessage = "Lista de Comentarios del usuario";
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string> { ex.ToString() };
            }

            return new OkObjectResult(_response);
        }
        public async Task<ActionResult<IEnumerable<ComentarioDTO>>> GetComentariosByuserByPaginacion(string username, int page, int pageSize)
        {
            try
            {
                ICollection<ComentarioDTO> lista = await _comentarioRepository.GetComentariosByuserByPaginacion(username, page, pageSize);
                _response.Result = lista;
                _response.DisplayMessage = "Lista de Comentarios del usuario";
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string> { ex.ToString() };
            }

            return new OkObjectResult(_response);
        }


        private async Task<ICollection<ComentarioDTO>> GetComentariosByuserByFiltro(string username, ComentariosFiltros? filtros)
        {
            if (filtros == null) {
                return await _comentarioRepository.GetComentariosByUser(username);
            }
            if (filtros.fechaIni == null)
            {
                filtros.fechaIni = DateTime.MinValue;
            }
            if (filtros.fechaFin == null)
            {
                filtros.fechaFin = DateTime.MaxValue;
            }

            if (filtros.idProducto !=null)
            {
                return await _comentarioRepository.GetComentariosByUserByDateAndProduct(username, filtros.fechaIni, filtros.fechaFin, (int)filtros.idProducto);

            }

            return await _comentarioRepository.GetComentariosByUserByDate(username,filtros.fechaIni,filtros.fechaFin);
           

        }

        public async Task<ActionResult<int>> GetCantComentariosByUser(string username)
        {
            try
            {
                int cant = await _comentarioRepository.GetCantComentariosByUser(username);
                _response.Result = cant;
                _response.DisplayMessage = "Cantidad de Comentarios del usuario";
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Result = 0;
                _response.ErrorMessages = new List<string> { ex.ToString() };
            }

            return new OkObjectResult(_response);
        }

        public async Task<ActionResult<IEnumerable<ComentarioDTO>>> GetComentariosReducidoConCategorias(ComentariosFiltros? filtros)
        {
            try
            {
                var lista = await _comentarioRepository.GetComentariosReducidoConCategorias(filtros);
                _response.FiltroInfo = filtros;
                _response.Result = lista;
                _response.DisplayMessage = "Lista de id Comentarios con Categorias";
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string> { ex.ToString() };
            }

            return new OkObjectResult(_response);
        }
    }
}

