using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PrediccionSentiminetoBack.Models;
using PrediccionSentiminetoBack.Models.DTO;
using PrediccionSentiminetoBack.Models.Request;
using PrediccionSentiminetoBack.Repository.Interfaces;
using System.Drawing.Printing;

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
            ICollection<Comentario> comentarios = await _db.Comentario.ToListAsync();
            return _mapper.Map<ICollection<ComentarioDTO>>(comentarios);
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

        public async Task<ICollection<ComentarioDTO>> GetComentariosByUserByDate(string username, DateTime? ini, DateTime? fin)
        {
            ICollection<Comentario> comentarios = await _db.Comentario.Where(c => c.UserName == username && c.Fecha >= ini && c.Fecha <= fin).ToListAsync();
            return _mapper.Map<ICollection<ComentarioDTO>>(comentarios);
        }

        public async Task<ICollection<ComentarioDTO>> GetComentariosByUserByDateAndProduct(string username, DateTime? ini, DateTime? fin, int idProducto)
        {
            ICollection<Comentario> comentarios = await _db.Comentario.Where(c => c.UserName == username && c.ProductoId == idProducto && c.Fecha >= ini && c.Fecha <= fin).ToListAsync();
            return _mapper.Map<ICollection<ComentarioDTO>>(comentarios);
        }

        public async Task<ICollection<ComentarioDTO>> GetComentariosByuserByPaginacion(string username, int page, int pageSize)
        {
            ICollection<Comentario> comentarios = await _db.Comentario.Skip((page - 1) * pageSize).Take(pageSize)
                .Where(c => c.UserName == username).ToListAsync();
            return _mapper.Map<ICollection<ComentarioDTO>>(comentarios);

        }

        public async Task<int> GetCantComentariosByUser(string username)
        {
            int cantidadComentarios = await _db.Comentario
                .Where(c => c.UserName == username)
                .CountAsync();
            return cantidadComentarios;
        }

        public async Task<ICollection<RelacionComCatDTO>> GetComentariosReducidoConCategorias(ComentariosFiltros? filtros)
        {
            var consulta = _db.Comentario
            .Where(c => c.Producto != null &&
                (filtros == null ||
                    ((filtros.fechaIni == null || c.Fecha >= filtros.fechaIni) &&
                     (filtros.fechaFin == null || c.Fecha <= filtros.fechaFin) &&
                     (filtros.userName == null || c.UserName.Equals(filtros.userName)) &&
                     (filtros.idProducto == null || c.ProductoId == filtros.idProducto))
                )
            );

            var total = await consulta.CountAsync();
            if (filtros.paginacion)
            {
                consulta = consulta.Skip((filtros.pageNumber - 1) * filtros.pageSize)
                                    .Take(filtros.pageSize);
            }

            List<RelacionComCatDTO> resultado = await consulta
                .SelectMany(c => c.Producto.Categorias
                    .Where(cat => filtros == null || filtros.categoriasId == null || filtros.categoriasId.Count() > 0 || filtros.categoriasId.Contains(cat.Id)) // Filtro adicional para categorías
                    .Select(cat => new RelacionComCatDTO
                    {
                        IdComentario = c.Id,
                        IdCategoria = cat.Id,
                        CodMes = c.Fecha.HasValue ? c.Fecha.Value.ToString("yyyyMM") : null,
                        NombreCategoria = cat.Nombre,
                        NombreProducto = c.Producto.Nombre,
                        CodCliente = c.Cliente.CodCliente
                    })
                )
                .ToListAsync();

            filtros.totalItems = total;
            filtros.totalPages = (int)Math.Ceiling(filtros.totalItems / (double)filtros.pageSize);

            return resultado;

        }
    }
}
