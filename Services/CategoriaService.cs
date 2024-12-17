using Microsoft.AspNetCore.Mvc;
using PrediccionSentiminetoBack.Models.DTO;
using PrediccionSentiminetoBack.Models.Request;
using PrediccionSentiminetoBack.Repository;
using PrediccionSentiminetoBack.Repository.Interfaces;
using PrediccionSentiminetoBack.Services.Interfaces;

namespace PrediccionSentiminetoBack.Services
{
    public class CategoriaService : ICategoriaService
    {

        private readonly ICategoriaRepository _categoriaRepository;
        protected ResponseDTO _response;

        public CategoriaService(ICategoriaRepository categoriaRepository)
        {
            _categoriaRepository = categoriaRepository;
            _response = new ResponseDTO();
        }
        public async Task<ActionResult<CategoriaDTO>> CreateCategoria(CategoriaDTO categoriaDTO)
        {
            try
            {
                CategoriaDTO exist = await _categoriaRepository.ExisteInUser(categoriaDTO);
                if (exist==null)
                {
                    CategoriaDTO model = await _categoriaRepository.CreateCategoria(categoriaDTO);
                    _response.Result = model;
                    return new CreatedAtActionResult("GetCategoria", "Categoria", new { id = model.Id }, _response);
                }
                else
                {
                    _response.Result = exist;
                    _response.DisplayMessage = "La Categoria ya existe en el Usuario";
                    return new OkObjectResult(_response);
                }
                }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.DisplayMessage = "Error al registrar el categoria";
                _response.ErrorMessages = new List<string> { ex.ToString() };
                return new BadRequestObjectResult(_response);
            }
        }

        public async Task<IActionResult> DeleteCategoria(int id)
        {
            try
            {
                bool eliminado = await _categoriaRepository.DeleteCategoria(id);
                if (eliminado)
                {
                    _response.Result = eliminado;
                    _response.DisplayMessage = "Categoria eliminada con exito";
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

        public async Task<ActionResult<CategoriaDTO>> GetCategoriaById(int id)
        {
            var categoria = await _categoriaRepository.GetCategoriaById(id);
            if (categoria == null)
            {
                _response.IsSuccess = false;
                _response.DisplayMessage = "La Categoria no Existe";
                return new NotFoundObjectResult(_response);

            }
            else
            {
                _response.Result = categoria;
                _response.DisplayMessage = "Información de la categoria";
                return new OkObjectResult(_response);
            }
        }

        public async Task<ActionResult<IEnumerable<CategoriaDTO>>> GetCategorias()
        {
            try
            {
                var lista = await _categoriaRepository.GetCategorias();
                _response.Result = lista;
                _response.DisplayMessage = "Lista de Categorias";
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string> { ex.ToString() };
            }

            return new OkObjectResult(_response);
        }

        public async Task<IActionResult> UpdateCategoria(int id, CategoriaDTO categoriaDTO)
        {
            try
            {
                if (id != categoriaDTO.Id)
                {
                    _response.DisplayMessage = "El id no coincide";
                    return new BadRequestObjectResult(_response);
                }
                CategoriaDTO model = await _categoriaRepository.UpdateCategoria(categoriaDTO);
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

        public async Task<ActionResult<IEnumerable<CategoriaDTO>>> GetCategoriasByUser(string username)
        {
            try
            {
                var lista = await _categoriaRepository.GetCategoriasByUser(username);
                _response.Result = lista;
                _response.DisplayMessage = "Lista de Categorias por usuario";
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string> { ex.ToString() };
            }

            return new OkObjectResult(_response);
        }
        public async Task<ActionResult<CategoriaDTO>> GetCategoriaByIdByUser(string usernamem, int id)
        {
            var categoria = await _categoriaRepository.GetCategoriaByIdByUser(usernamem,id);
            if (categoria == null)
            {
                _response.IsSuccess = false;
                _response.DisplayMessage = "La Categoria del usuario no Existe";
                return new NotFoundObjectResult(_response);

            }
            else
            {
                _response.Result = categoria;
                _response.DisplayMessage = "Información de la categoria del usuario";
                return new OkObjectResult(_response);
            }
        }

        public async Task<ActionResult<CategoriaDTO>> GetCategoriaByNameByUser(string usernamem, string name)
        {
            var categoria = await _categoriaRepository.GetCategoriaByNameByUser(usernamem, name);
            if (categoria == null)
            {
                _response.IsSuccess = false;
                _response.DisplayMessage = "La Categoria del usuario no Existe";
                return new NotFoundObjectResult(_response);

            }
            else
            {
                _response.Result = categoria;
                _response.DisplayMessage = "Información de la categoria del usuario";
                return new OkObjectResult(_response);
            }
        }

        public async Task<ActionResult<IEnumerable<CategoriaDTO>>> GetCategoriasByUserConComentarios(string username, CategoriasFiltros? filtros)
        {
            try
            {
                object lista = await GetCategoriasByuserConComentariosByFiltro(username, filtros);
                _response.Result = lista;
                _response.DisplayMessage = "Lista de Categorias por usuario";
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string> { ex.ToString() };
            }

            return new OkObjectResult(_response);
        }

        private async Task<object> GetCategoriasByuserConComentariosByFiltro(string username, CategoriasFiltros? filtros)
        {
            if (filtros == null)
            {
                filtros = new CategoriasFiltros();
            }
            if (filtros.fechaIni == null)
            {
                filtros.fechaIni = DateTime.MinValue;
            }
            if (filtros.fechaFin == null)
            {
                filtros.fechaFin = DateTime.MaxValue;
            }

            if (filtros.categoriasId != null && filtros.categoriasId.Count != 0)
            {
                return await _categoriaRepository.GetCategoriasByUserConComentariosFiltroIds(username, filtros.fechaIni, filtros.fechaFin, filtros.categoriasId);

            }
            return await _categoriaRepository.GetCategoriasByUserConComentarios(username,filtros.fechaIni,filtros.fechaFin);
        }
    }
}
