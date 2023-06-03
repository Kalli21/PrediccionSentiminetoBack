﻿using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PrediccionSentiminetoBack.Models;
using PrediccionSentiminetoBack.Models.DTO;
using PrediccionSentiminetoBack.Repository.Interfaces;

namespace PrediccionSentiminetoBack.Repository
{
    public class ProductoRepository : IProductoRepository
    {
        private readonly PrediccionSentiminetoBackContext _db;
        private IMapper _mapper;

        public ProductoRepository(PrediccionSentiminetoBackContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<ProductoDTO> CreateProducto(ProductoDTO productoDTO)
        {
            Producto producto = _mapper.Map<ProductoDTO, Producto>(productoDTO);
            await _db.Producto.AddAsync(producto);
            await _db.SaveChangesAsync();
            return _mapper.Map<Producto, ProductoDTO>(producto);
        }

        public async Task<bool> DeleteProducto(int id)
        {
            try
            {
                Producto producto = await _db.Producto.FindAsync(id);
                if (producto == null)
                    return false;
                _db.Producto.Remove(producto);
                await _db.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }        

        public async Task<ProductoDTO> GetProductoById(int id)
        {
            Producto producto = await _db.Producto.FindAsync(id);
            return _mapper.Map<ProductoDTO>(producto);
        }

        public async Task<ICollection<ProductoDTO>> GetProductos()
        {
            ICollection<Producto> categorias = await _db.Producto.ToListAsync();
            return _mapper.Map<ICollection<ProductoDTO>>(categorias);
        }

        public async Task<ProductoDTO> UpdateProducto(ProductoDTO productoDTO)
        {
            Producto producto = _mapper.Map<ProductoDTO, Producto>(productoDTO);
            _db.Producto.Update(producto);
            await _db.SaveChangesAsync();
            return _mapper.Map<Producto, ProductoDTO>(producto);
        }

        public async Task<bool> ExisteInUser(ProductoDTO productoDTO)
        {
            if (await _db.Producto.AnyAsync(x =>  
                x.UsuarioId.Equals(productoDTO.UsuarioId) &&
                x.CodProducto.ToLower().Equals(productoDTO.CodProducto.ToLower())))
            {
                return true;
            }
            return false;
        }
    }
}
