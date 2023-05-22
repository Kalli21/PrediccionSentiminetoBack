using Microsoft.AspNetCore.Mvc;
using PrediccionSentiminetoBack.Models.DTO;

namespace PrediccionSentiminetoBack.Services.Interfaces
{
    public interface IUsuarioService
    {
        Task<IActionResult> Register(UsuarioDTO user);
        Task<IActionResult> Login(UsuarioDTO user);

        Task<ActionResult<IEnumerable<UsuarioDTO>>> GetUsers();
        Task<ActionResult<UsuarioDTO>> GetUserById(string username);
        Task<IActionResult> UpdateUser(string username, UsuarioDTO usuarioDTO);
        Task<IActionResult> DeleteUser(string username);
    }
}
