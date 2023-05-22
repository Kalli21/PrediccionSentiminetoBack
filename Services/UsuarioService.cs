using Microsoft.AspNetCore.Mvc;
using PrediccionSentiminetoBack.Models.DTO;
using PrediccionSentiminetoBack.Repository.Interfaces;
using PrediccionSentiminetoBack.Services.Interfaces;

namespace PrediccionSentiminetoBack.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;
        protected ResponseDTO _response;

        public UsuarioService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
            _response = new ResponseDTO();
        }
        public async Task<IActionResult> DeleteUser(string username)
        {
            try
            {
                bool eliminado = await _usuarioRepository.DeleteUser(username);
                if (eliminado)
                {
                    _response.Result = eliminado;
                    _response.DisplayMessage = "Usuario eliminado con exito";
                    return new OkObjectResult(_response);
                }
                else
                {
                    _response.IsSuccess = false;
                    _response.DisplayMessage = "Error al eliminar user";
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

        public async Task<ActionResult<UsuarioDTO>> GetUserById(string username)
        {
            var user = await _usuarioRepository.GetUserById(username);
            if (user == null)
            {
                _response.IsSuccess = false;
                _response.DisplayMessage = "Usuario no Existe";
                return new NotFoundObjectResult(_response);

            }
            else
            {
                _response.Result = user;
                _response.DisplayMessage = "Información del usuario";
                return new OkObjectResult(_response);
            }
        }

        public async Task<ActionResult<IEnumerable<UsuarioDTO>>> GetUsers()
        {
            try
            {
                var lista = await _usuarioRepository.GetUsers();
                _response.Result = lista;
                _response.DisplayMessage = "Lista de Usuarios";
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string> { ex.ToString() };
            }

            return new OkObjectResult(_response);
        }

        public async Task<IActionResult> Login(UsuarioDTO user)
        {
            UsuarioDTO model = await _usuarioRepository.Login(user);

            if (model.Token == "nouser")
            {
                _response.IsSuccess = false;
                _response.DisplayMessage = "Usuario no existe";
                return new BadRequestObjectResult(_response);
            }

            if (model.Token == "wrongpassword")
            {
                _response.IsSuccess = false;
                _response.DisplayMessage = "Password incorrecto";
                return new BadRequestObjectResult(_response);
            }

            //_response.Result = respuesta;
            _response.DisplayMessage = "Usuario conectado";

            // user.Token = respuesta;
            model.Password = "";
            _response.Result = model;

            return new OkObjectResult(_response);

        }

        public async Task<IActionResult> Register(UsuarioDTO user)
        {
            UsuarioDTO model = await _usuarioRepository.Register(user);

            if (model.Token == "existe")
            {
                _response.IsSuccess = false;
                _response.DisplayMessage = "Usuario ya Existe";
                return new BadRequestObjectResult(_response);
            }

            if (model.Token == "error")
            {
                _response.IsSuccess = false;
                _response.DisplayMessage = "Error al Crear el Usuario";
                return new BadRequestObjectResult(_response);
            }

            _response.DisplayMessage = "Usuario creado con Exito";
            _response.Result = model;
            return new OkObjectResult(_response);
        }

        public async Task<IActionResult> UpdateUser(string username, UsuarioDTO usuarioDTO)
        {
            try
            {
                if (username != usuarioDTO.UserName)
                {
                    _response.DisplayMessage = "El username no coincide";
                    return new BadRequestObjectResult(_response);
                }
                UsuarioDTO model = await _usuarioRepository.UpdateUser(usuarioDTO);
                _response.Result = model;
                return new OkObjectResult(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.DisplayMessage = "Error al actualizar el usuario";
                _response.ErrorMessages = new List<string> { ex.ToString() };
                return new BadRequestObjectResult(_response);
            }
        }
    }
}
