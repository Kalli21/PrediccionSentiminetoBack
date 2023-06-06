using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PrediccionSentiminetoBack.Models;
using PrediccionSentiminetoBack.Models.DTO;
using PrediccionSentiminetoBack.Repository.Interfaces;

namespace PrediccionSentiminetoBack.Repository
{
    public class ComentarioRepository : IComentarioRepository
    {
        private readonly PrediccionSentiminetoBackContext _db;
        private IMapper _mapper;

        public ComentarioRepository(PrediccionSentiminetoBackContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }
        public async Task<ComentarioDTO> CreateComentario(ComentarioDTO comentarioDTO)
        {
            Comentario comentario = _mapper.Map<ComentarioDTO, Comentario>(comentarioDTO);
            await _db.Comentario.AddAsync(comentario);
            await _db.SaveChangesAsync();
            return _mapper.Map<Comentario, ComentarioDTO>(comentario);
        }

        public async Task<bool> DeleteComentario(int id)
        {
            try
            {
                Comentario comentario = await _db.Comentario.FindAsync(id);
                if (comentario == null)
                    return false;
                _db.Comentario.Remove(comentario);
                await _db.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<ComentarioDTO> GetComentarioById(int id)
        {
            Comentario comentario = await _db.Comentario.FindAsync(id);
            return _mapper.Map<ComentarioDTO>(comentario);
        }

        public async Task<ICollection<ComentarioDTO>> GetComentarios()
        {
            ICollection<Comentario> categorias = await _db.Comentario.ToListAsync();
            return _mapper.Map<ICollection<ComentarioDTO>>(categorias);
        }

        public async Task<ComentarioDTO> UpdateComentario(ComentarioDTO comentarioDTO)
        {
            Comentario comentario = _mapper.Map<ComentarioDTO, Comentario>(comentarioDTO);
            _db.Comentario.Update(comentario);
            await _db.SaveChangesAsync();
            return _mapper.Map<Comentario, ComentarioDTO>(comentario);
        }

        public async Task<ICollection<ComentarioDTO>> GetComentariosByUser(string username)
        {
            ICollection<Comentario> comentarios = await _db.Comentario.Where(c => c.UserName == username).ToListAsync();
            return _mapper.Map<ICollection<ComentarioDTO>>(comentarios);
        }
        public async Task<ComentarioDTO> GetComentarioByIdByUser(string username, int id)
        {
            Comentario comentario = await _db.Comentario.FirstOrDefaultAsync(c => c.Id == id && c.UserName == username);
            return _mapper.Map<ComentarioDTO>(comentario);
        }


    }
}
