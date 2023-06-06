
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PrediccionSentiminetoBack.Models.DTO;
using PrediccionSentiminetoBack.Services;
using PrediccionSentiminetoBack.Services.Interfaces;

namespace PrediccionSentiminetoBack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteService _clienteService;

        public ClienteController(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        // GET: api/Cliente
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClienteDTO>>> GetCliente()
        {
            return await _clienteService.GetClientes();
        }

        // GET: api/Cliente/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ClienteDTO>> GetCliente(int id)
        {
            return await _clienteService.GetClienteById(id);
        }

        // PUT: api/Cliente/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCliente(int id, ClienteDTO clienteDTO)
        {
            return await _clienteService.UpdateCliente(id, clienteDTO);

        }

        // POST: api/Cliente
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ClienteDTO>> PostCliente(ClienteDTO clienteDTO)
        {
            return await _clienteService.CreateCliente(clienteDTO);
        }

        // DELETE: api/Cliente/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCliente(int id)
        {
            return await _clienteService.DeleteCliente(id);
        }

        // GET: api/Cliente/username
        [HttpGet("username/{username}")]
        public async Task<ActionResult<IEnumerable<ClienteDTO>>> GetClientesByUser(string username)
        {
            return await _clienteService.GetClientesByUser(username);
        }

        // GET: api/Cliente/username/5
        [HttpGet("username/{username}/{id}")]
        public async Task<ActionResult<ClienteDTO>> GetClienteByUserAndId(string username, int id)
        {
            return await _clienteService.GetClienteByIdByUser(username, id);
        }

    }
}
