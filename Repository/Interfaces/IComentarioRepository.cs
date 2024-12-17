using Microsoft.VisualBasic;
using PrediccionSentiminetoBack.Models.DTO;
using PrediccionSentiminetoBack.Models.Request;

namespace PrediccionSentiminetoBack.Repository.Interfaces
{
    public interface IComentarioRepository
    {
        Task<ICollection<ComentarioDTO>> GetComentarios();
        Task<ComentarioDTO> GetComentarioById(int id);
        Task<ComentarioDTO> CreateComentario(ComentarioDTO comentarioDTO);
        Task<ComentarioDTO> UpdateComentario(ComentarioDTO comentarioDTO);
        Task<bool> DeleteComentario(int id);
        Task<ICollection<ComentarioDTO>> GetComentariosByUser(string username);
        Task<ComentarioDTO> GetComentarioByIdByUser(string username, int id);

        Task<int> GetCantComentariosByUser(string username);

        Task<ICollection<ComentarioDTO>> GetComentariosByUserByDate(string username, DateTime? ini, DateTime? fin);
        Task<ICollection<ComentarioDTO>> GetComentariosByUserByDateAndProduct(string username, DateTime? ini, DateTime? fin, int idProducto);
        Task<ICollection<ComentarioDTO>> GetComentariosByuserByPaginacion(string username, int page, int pageSize);
        Task<ICollection<RelacionComCatDTO>> GetComentariosReducidoConCategorias(ComentariosFiltros? filtros);

    }
}
