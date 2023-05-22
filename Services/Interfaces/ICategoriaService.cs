﻿using Microsoft.AspNetCore.Mvc;
using PrediccionSentiminetoBack.Models.DTO;

namespace PrediccionSentiminetoBack.Services.Interfaces
{
    public interface ICategoriaService
    {
        Task<ActionResult<IEnumerable<CategoriaDTO>>> GetCategorias();
        Task<ActionResult<CategoriaDTO>> GetCategoriaById(int id);
        Task<ActionResult<CategoriaDTO>> CreateCategoria(CategoriaDTO categoriaDTO);
        Task<IActionResult> UpdateCategoria(int id, CategoriaDTO categoriaDTO);
        Task<IActionResult> DeleteCategoria(int id);

    }
}
