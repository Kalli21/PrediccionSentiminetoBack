using Microsoft.AspNetCore.Mvc;
using PrediccionSentiminetoBack.Models.DTO;

namespace PrediccionSentiminetoBack.Services.Interfaces
{
    public interface IClienteService
    {
        Task<ActionResult<IEnumerable<ClienteDTO>>> GetClientes();
        Task<ActionResult<ClienteDTO>> GetClienteById(int id);
        Task<ActionResult<ClienteDTO>> CreateCliente(ClienteDTO clienteDTO);
        Task<IActionResult> UpdateCliente(int id, ClienteDTO clienteDTO);
        Task<IActionResult> DeleteCliente(int id);
    }
}
