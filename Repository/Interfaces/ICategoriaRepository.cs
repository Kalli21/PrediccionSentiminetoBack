using PrediccionSentiminetoBack.Models.DTO;

namespace PrediccionSentiminetoBack.Repository.Interfaces
{
    public interface ICategoriaRepository
    {
        Task<ICollection<CategoriaDTO>> GetCategorias();
        Task<CategoriaDTO> GetCategoriaById(int id);
        Task<CategoriaDTO> CreateCategoria(CategoriaDTO categoriaDTO);
        Task<CategoriaDTO> UpdateCategoria(CategoriaDTO categoriaDTO);
        Task<bool> DeleteCategoria(int id);
        Task<CategoriaDTO> ExisteInUser(CategoriaDTO categoriaDTO);
        Task<ICollection<CategoriaDTO>> GetCategoriasByUser(string username);
        Task<CategoriaDTO> GetCategoriaByIdByUser(string username,int id);
        Task<CategoriaDTO> GetCategoriaByNameByUser(string username, string name);
    }
}
