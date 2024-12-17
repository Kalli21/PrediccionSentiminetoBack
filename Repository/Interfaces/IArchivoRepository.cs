using PrediccionSentiminetoBack.Models.DTO;

namespace PrediccionSentiminetoBack.Repository.Interfaces
{
    public interface IArchivoRepository
    {
        Task<ICollection<ArchivoDTO>> GetArchivos();
        Task<ArchivoDTO> GetArchivoById(int id);
        Task<ArchivoDTO> CreateArchivo(ArchivoDTO archivoDTO);
        Task<ArchivoDTO> UpdateArchivo(ArchivoDTO archivoDTO);
        Task<bool> DeleteArchivo(int id);
    }
}
