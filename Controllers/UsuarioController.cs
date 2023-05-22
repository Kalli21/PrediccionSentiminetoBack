using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PrediccionSentiminetoBack.Models;
using PrediccionSentiminetoBack.Models.DTO;
using PrediccionSentiminetoBack.Services.Interfaces;

namespace PrediccionSentiminetoBack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;

        public UsuarioController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register(UsuarioDTO user)
        {
            return await _usuarioService.Register(user);
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(UsuarioDTO user)
        {
            return await _usuarioService.Login(user);
        }

        // GET: api/Usuario
        [HttpGet]
        [Authorize]
        public async Task<ActionResult<IEnumerable<UsuarioDTO>>> GetUsuario()
        {
            return await _usuarioService.GetUsers();
        }

        // GET: api/Usuario/5
        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<UsuarioDTO>> GetUsuario(string id)
        {
            return await _usuarioService.GetUserById(id);
        }

        // PUT: api/Usuario/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> PutUsuario(string id, UsuarioDTO usuarioDTO)
        {
            return await _usuarioService.UpdateUser(id, usuarioDTO);
        }

 

        // DELETE: api/Usuario/5
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> DeleteUsuario(string id)
        {
            return await _usuarioService.DeleteUser(id);
        }

    }
}
