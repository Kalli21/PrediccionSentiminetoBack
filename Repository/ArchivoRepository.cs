using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PrediccionSentiminetoBack.Models;
using PrediccionSentiminetoBack.Models.DTO;
using PrediccionSentiminetoBack.Repository.Interfaces;

namespace PrediccionSentiminetoBack.Repository
{
    public class ArchivoRepository : IArchivoRepository
    {
        private readonly PrediccionSentiminetoBackContext _db;
        private IMapper _mapper;

        public ArchivoRepository(PrediccionSentiminetoBackContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<ArchivoDTO> CreateArchivo(ArchivoDTO archivoDTO)
        {
            Archivo archivo = _mapper.Map<ArchivoDTO, Archivo>(archivoDTO);
            await _db.Archivo.AddAsync(archivo);
            await _db.SaveChangesAsync();
            return _mapper.Map<Archivo, ArchivoDTO>(archivo);
        }

        public async Task<bool> DeleteArchivo(int id)
        {
            try
            {
                Archivo archivo = await _db.Archivo.FindAsync(id);
                if (archivo == null)
                    return false;
                _db.Archivo.Remove(archivo);
                await _db.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<ArchivoDTO> GetArchivoById(int id)
        {
            Archivo archivo = await _db.Archivo.FirstOrDefaultAsync(c => c.Id == id);
            return _mapper.Map<ArchivoDTO>(archivo);
        }

        public async Task<ICollection<ArchivoDTO>> GetArchivos()
        {
            ICollection<Archivo> archivos = await _db.Archivo.ToListAsync();
            return _mapper.Map<ICollection<ArchivoDTO>>(archivos); ;
        }

        public async Task<ArchivoDTO> UpdateArchivo(ArchivoDTO archivoDTO)
        {
            Archivo archivo = _mapper.Map<ArchivoDTO, Archivo>(archivoDTO);
            _db.Archivo.Update(archivo);
            await _db.SaveChangesAsync();
            return _mapper.Map<Archivo, ArchivoDTO>(archivo);
        }
    }
}
