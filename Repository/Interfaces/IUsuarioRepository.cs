using PrediccionSentiminetoBack.Models.DTO;

namespace PrediccionSentiminetoBack.Repository.Interfaces
{
    public interface IUsuarioRepository
    {
        Task<UsuarioDTO> Register(UsuarioDTO usuarioDTO);
        Task<UsuarioDTO> Login(UsuarioDTO usuarioDTO);
        Task<bool> UserExiste(string username);
        Task<ICollection<UsuarioDTO>> GetUsers();
        Task<UsuarioDTO> GetUserById(string username);
        Task<UsuarioDTO> UpdateUser(UsuarioDTO usuarioDTO);
        Task<bool> DeleteUser(string username);
        Task<bool> DeleteInfoUser(string username);

    }
}
