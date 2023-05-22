using PrediccionSentiminetoBack.Models.DTO;

namespace PrediccionSentiminetoBack.Repository.Interfaces
{
    public interface IComentarioRepository
    {
        Task<ICollection<ComentarioDTO>> GetComentarios();
        Task<ComentarioDTO> GetComentarioById(int id);
        Task<ComentarioDTO> CreateComentario(ComentarioDTO comentarioDTO);
        Task<ComentarioDTO> UpdateComentario(ComentarioDTO comentarioDTO);
        Task<bool> DeleteComentario(int id);
    }
}
