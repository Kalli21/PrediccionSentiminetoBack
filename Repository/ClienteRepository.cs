using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PrediccionSentiminetoBack.Models;
using PrediccionSentiminetoBack.Models.DTO;
using PrediccionSentiminetoBack.Repository.Interfaces;

namespace PrediccionSentiminetoBack.Repository
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly PrediccionSentiminetoBackContext _db;
        private IMapper _mapper;

        public ClienteRepository(PrediccionSentiminetoBackContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        } 
        public async Task<ClienteDTO> CreateCliente(ClienteDTO clienteDTO)
        {
            Cliente cliente = _mapper.Map<ClienteDTO, Cliente>(clienteDTO);
            await _db.Cliente.AddAsync(cliente);
            await _db.SaveChangesAsync();
            return _mapper.Map<Cliente, ClienteDTO>(cliente);
        
        }

        public async Task<bool> DeleteCliente(int id)
        {
             try
            {
                Cliente cliente = await _db.Cliente.FindAsync(id);
                if (cliente == null)
                    return false;
                _db.Cliente.Remove(cliente);
                await _db.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<ClienteDTO> GetClienteById(int id)
        {
            Cliente cliente = await _db.Cliente.FindAsync(id);
            return _mapper.Map<ClienteDTO>(cliente);
        }

        public async Task<ICollection<ClienteDTO>> GetClientes()
        {
            ICollection<Cliente> clientes = await _db.Cliente.ToListAsync();
            return _mapper.Map<ICollection<ClienteDTO>>(clientes);
        
        }

        public async Task<ClienteDTO> UpdateCliente(ClienteDTO clienteDTO)
        {
            Cliente cliente = _mapper.Map<ClienteDTO, Cliente>(clienteDTO);
            _db.Cliente.Update(cliente);
            await _db.SaveChangesAsync();
            return _mapper.Map<Cliente, ClienteDTO>(cliente);
        
        }
    }
}
