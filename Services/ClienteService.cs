using Azure;
using Microsoft.AspNetCore.Mvc;
using PrediccionSentiminetoBack.Models.DTO;
using PrediccionSentiminetoBack.Repository;
using PrediccionSentiminetoBack.Repository.Interfaces;
using PrediccionSentiminetoBack.Services.Interfaces;

namespace PrediccionSentiminetoBack.Services
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _clienteRepository;
        protected ResponseDTO _response;

        public ClienteService(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
            _response = new ResponseDTO();
        }

        public async Task<ActionResult<ClienteDTO>> CreateCliente(ClienteDTO clienteDTO)
        {
            try
            {
                ClienteDTO exist = await _clienteRepository.ExisteInUser(clienteDTO);
                if (exist==null)
                {
                    ClienteDTO model = await _clienteRepository.CreateCliente(clienteDTO);
                    _response.Result = model;
                    return new CreatedAtActionResult("GetCliente", "Cliente", new { id = model.Id }, _response);
                }
                else
                {
                    _response.Result = exist;
                    _response.DisplayMessage = "El Cliente ya existe en el Usuario";
                    return new OkObjectResult(_response);
                }
                }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.DisplayMessage = "Error al registrar el cliente";
                _response.ErrorMessages = new List<string> { ex.ToString() };
                return new BadRequestObjectResult(_response);
            }
        }

        public async Task<IActionResult> DeleteCliente(int id)
        {
            try
            {
                bool eliminado = await _clienteRepository.DeleteCliente(id);
                if (eliminado)
                {
                    _response.Result = eliminado;
                    _response.DisplayMessage = "Cliente eliminado con exito";
                    return new OkObjectResult(_response);
                }
                else
                {
                    _response.IsSuccess = false;
                    _response.DisplayMessage = "Error al eliminar cliente";
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

        public async Task<ActionResult<ClienteDTO>> GetClienteById(int id)
        {
            var cliente = await _clienteRepository.GetClienteById(id);
            if (cliente == null)
            {
                _response.IsSuccess = false;
                _response.DisplayMessage = "La Categoria no Existe";
                return new NotFoundObjectResult(_response);

            }
            else
            {
                _response.Result = cliente;
                _response.DisplayMessage = "Información del cliente";
                return new OkObjectResult(_response);
            }
        }

        public async Task<ActionResult<IEnumerable<ClienteDTO>>> GetClientes()
        {
            try
            {
                var lista = await _clienteRepository.GetClientes();
                _response.Result = lista;
                _response.DisplayMessage = "Lista de clientes";
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string> { ex.ToString() };
            }

            return new OkObjectResult(_response);
        }

        public async Task<IActionResult> UpdateCliente(int id, ClienteDTO clienteDTO)
        {
            try
            {
                if (id != clienteDTO.Id)
                {
                    _response.DisplayMessage = "El id no coincide";
                    return new BadRequestObjectResult(_response);
                }
                ClienteDTO model = await _clienteRepository.UpdateCliente(clienteDTO);
                _response.Result = model;
                return new OkObjectResult(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.DisplayMessage = "Error al actualizar el cliente";
                _response.ErrorMessages = new List<string> { ex.ToString() };
                return new BadRequestObjectResult(_response);
            }
        }

        public async Task<ActionResult<IEnumerable<ClienteDTO>>> GetClientesByUser(string username)
        {
            try
            {
                var lista = await _clienteRepository.GetClientesByUser(username);
                _response.Result = lista;
                _response.DisplayMessage = "Lista de clientes del usuario";
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string> { ex.ToString() };
            }

            return new OkObjectResult(_response);
        }
        public async Task<ActionResult<ClienteDTO>> GetClienteByIdByUser(string username, int id)
        {
            var cliente = await _clienteRepository.GetClienteByIdByUser(username,id);
            if (cliente == null)
            {
                _response.IsSuccess = false;
                _response.DisplayMessage = "La Categoria no Existe en el usuario";
                return new NotFoundObjectResult(_response);

            }
            else
            {
                _response.Result = cliente;
                _response.DisplayMessage = "Información del cliente del usuario";
                return new OkObjectResult(_response);
            }
        }

    }
}
