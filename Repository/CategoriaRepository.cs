using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PrediccionSentiminetoBack.Models;
using PrediccionSentiminetoBack.Models.DTO;
using PrediccionSentiminetoBack.Repository.Interfaces;

namespace PrediccionSentiminetoBack.Repository
{
    public class CategoriaRepository : ICategoriaRepository
    {
        private readonly PrediccionSentiminetoBackContext _db;
        private IMapper _mapper;

        public CategoriaRepository(PrediccionSentiminetoBackContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<CategoriaDTO> CreateCategoria(CategoriaDTO categoriaDTO)
        {
            Categoria categoria = _mapper.Map<CategoriaDTO, Categoria>(categoriaDTO);
            await _db.Categoria.AddAsync(categoria);
            await _db.SaveChangesAsync();
            return _mapper.Map<Categoria, CategoriaDTO>(categoria);
        }

        public async Task<bool> DeleteCategoria(int id)
        {
            try
            {
                Categoria categoria = await _db.Categoria.FindAsync(id);
                if (categoria == null)
                    return false;
                _db.Categoria.Remove(categoria);
                await _db.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<CategoriaDTO> GetCategoriaById(int id)
        {
            Categoria categoria = await _db.Categoria.FindAsync(id);
            return _mapper.Map<CategoriaDTO>(categoria);
        }

        public async Task<ICollection<CategoriaDTO>> GetCategorias()
        {
            ICollection<Categoria> categorias = await _db.Categoria.ToListAsync();
            return _mapper.Map<ICollection<CategoriaDTO>>(categorias);
        }

        public async Task<CategoriaDTO> UpdateCategoria(CategoriaDTO categoriaDTO)
        {
            Categoria categoria = _mapper.Map<CategoriaDTO, Categoria>(categoriaDTO);
            _db.Categoria.Update(categoria);
            await _db.SaveChangesAsync();
            return _mapper.Map<Categoria, CategoriaDTO>(categoria);
        }
    }
}
