using PrediccionSentiminetoBack.Models.DTO;

namespace PrediccionSentiminetoBack.Repository.Interfaces
{
    public interface IClienteRepository
    {
        Task<ICollection<ClienteDTO>> GetClientes();
        Task<ClienteDTO> GetClienteById(int id);
        Task<ClienteDTO> CreateCliente(ClienteDTO clienteDTO);
        Task<ClienteDTO> UpdateCliente(ClienteDTO clienteDTO);
        Task<bool> DeleteCliente(int id);
        Task<bool> ExisteInUser(ClienteDTO clienteDTO);
    }
}
