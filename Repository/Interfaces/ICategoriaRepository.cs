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
    }
}
