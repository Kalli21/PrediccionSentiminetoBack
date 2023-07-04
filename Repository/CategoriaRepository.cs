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
            Categoria categoria = await _db.Categoria.Include(c => c.Productos).FirstOrDefaultAsync( c => c.Id == id);
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
        public async Task<CategoriaDTO> ExisteInUser(CategoriaDTO categoriaDTO)
        {
            var categoria = await _db.Categoria.FirstOrDefaultAsync(x =>
                x.UserName.ToLower().Equals(categoriaDTO.UserName.ToLower()) &&
                x.Nombre.ToLower().Equals(categoriaDTO.Nombre.ToLower()));
            if (categoria != null)
            {
                return _mapper.Map<Categoria, CategoriaDTO>(categoria);
            }

            return null;
        }

        public async Task<ICollection<CategoriaDTO>> GetCategoriasByUser(string username)
        {
            ICollection<Categoria> categorias = await _db.Categoria.Where(c => c.UserName == username).ToListAsync();
            return _mapper.Map<ICollection<CategoriaDTO>>(categorias);
        }

        public async Task<CategoriaDTO> GetCategoriaByIdByUser(string username, int id)
        {
            Categoria categoria = await _db.Categoria.Include(c => c.Productos).FirstOrDefaultAsync(c => c.Id == id && c.UserName == username);
            return _mapper.Map<CategoriaDTO>(categoria);
        }

        public async Task<CategoriaDTO> GetCategoriaByNameByUser(string username, string name)
        {
            Categoria categoria = await _db.Categoria.Include(c => c.Productos).FirstOrDefaultAsync(c => c.Nombre == name && c.UserName == username);
            return _mapper.Map<CategoriaDTO>(categoria);
        }

        public async Task<ICollection<CategoriaDTO>> GetCategoriasByUserConComentarios(string username, DateTime? ini, DateTime? fin)
        {
            ICollection<Categoria> categorias = await _db.Categoria
                .Where(c => c.UserName == username)
                .Include(c => c.Productos)
                    .ThenInclude(p => p.Comentarios.Where(com => com.Fecha >= ini && com.Fecha <= fin))
                .ToListAsync();
            return _mapper.Map<ICollection<CategoriaDTO>>(categorias);
        }
        public async Task<ICollection<CategoriaDTO>> GetCategoriasByUserConComentariosFiltroIds(string username, DateTime? ini, DateTime? fin, ICollection<int> categoriasIds)
        {
            ICollection<Categoria> categorias = await _db.Categoria
                .Where(c => c.UserName == username && categoriasIds.Contains(c.Id))
                .Include(c => c.Productos)
                    .ThenInclude(p => p.Comentarios.Where(com => com.Fecha >= ini && com.Fecha <= fin))
                .ToListAsync();
            return _mapper.Map<ICollection<CategoriaDTO>>(categorias);
        }
    }
}
