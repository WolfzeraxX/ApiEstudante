using CursoEstudanteAPI.API.DTOs;
using CursoEstudanteAPI.Application.Services;
using CursoEstudanteAPI.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CursoEstudanteAPI.API.Controller
{

    [ApiController]
    [Route("api/curso")]
    public class CursoController : ControllerBase
    {
        private readonly ICursoService _cursoService;

        public CursoController(ICursoService cursoService)
        {
            _cursoService = cursoService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            
            return Ok(await _cursoService.GetAllCursosAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var curso = await _cursoService.GetCursoByIdAsync(id);
            if (curso == null) return NotFound();
            return Ok(curso);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CursoDto cursoDto)
        {
            
            return Ok(await _cursoService.CreateCursoAsync(cursoDto));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, CursoDto cursoDto)
        {
            var updatedCurso = await _cursoService.UpdateCursoAsync(id, cursoDto);
            if (updatedCurso == null) return NotFound();
            return Ok(updatedCurso);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _cursoService.DeleteCursoAsync(id);
            return NoContent();
        }
    }

}
