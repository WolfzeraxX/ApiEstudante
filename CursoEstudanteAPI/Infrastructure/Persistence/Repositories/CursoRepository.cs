using CursoEstudanteAPI.API.DTOs;
using CursoEstudanteAPI.Domain.Entities;
using CursoEstudanteAPI.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CursoEstudanteAPI.Infrastructure.Persistence.Repositories
{
    public class CursoRepository : ICursoRepository
    {
        private readonly ApplicationDbContext _context;

        public CursoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<CursoDto>> GetAllAsync()
        {
            return await _context.Cursos.Select(x => new CursoDto {Id = x.Id, Nome = x.Nome, Descricao = x.Descricao  }).ToListAsync();
        }

        public async Task<Curso> GetByIdAsync(int id)
        {
            return await _context.Cursos.FindAsync(id);
        }

        public async Task<int> AddAsync(Curso curso)
        {
            await _context.Cursos.AddAsync(curso);
            await _context.SaveChangesAsync();
            return curso.Id;
        }

        public async Task UpdateAsync(Curso curso)
        {
            _context.Cursos.Update(curso);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Curso curso)
        {
            _context.Cursos.Remove(curso);
            await _context.SaveChangesAsync();
        }
    }
}
