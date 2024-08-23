using CursoEstudanteAPI.API.DTOs;
using CursoEstudanteAPI.Domain.Entities;
using CursoEstudanteAPI.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CursoEstudanteAPI.Infrastructure.Persistence.Repositories
{
    public class EstudanteRepository : IEstudanteRepository
    {
        private readonly ApplicationDbContext _context;

        public EstudanteRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<EstudanteDto>> GetAllAsync()
        {
            return await _context.Estudantes.Select(x =>  new EstudanteDto {Id = x.Id,Nome = x.Nome }).ToListAsync();
        }

        public async Task<Estudante> GetByIdAsync(int id)
        {
            return await _context.Estudantes.FindAsync(id);
        }

        public async Task AddAsync(Estudante estudante)
        {
            await _context.Estudantes.AddAsync(estudante);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Estudante estudante)
        {
            _context.Estudantes.Update(estudante);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Estudante estudante)
        {
            _context.Estudantes.Remove(estudante);
            await _context.SaveChangesAsync();
        }
    }
}
