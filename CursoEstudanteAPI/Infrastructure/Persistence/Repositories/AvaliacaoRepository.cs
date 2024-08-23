using CursoEstudanteAPI.Domain.Entities;
using CursoEstudanteAPI.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CursoEstudanteAPI.Infrastructure.Persistence.Repositories
{
    public class AvaliacaoRepository : IAvaliacaoRepository
    {
        private readonly ApplicationDbContext _context;

        public AvaliacaoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Avaliacao>> GetAllAsync()
        {
            return await _context.Avaliacoes
                .Include(a => a.Curso)
                .Include(a => a.Estudante)
                .ToListAsync();
        }

        public async Task<Avaliacao> GetByIdAsync(int id)
        {
            return await _context.Avaliacoes
                .Include(a => a.Curso)
                .Include(a => a.Estudante)
                .FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task AddAsync(Avaliacao avaliacao)
        {
            await _context.Avaliacoes.AddAsync(avaliacao);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Avaliacao avaliacao)
        {
            _context.Avaliacoes.Update(avaliacao);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Avaliacao avaliacao)
        {
            _context.Avaliacoes.Remove(avaliacao);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Avaliacao>> GetAvaliacoesByCursoAsync(int cursoId)
        {
            return await _context.Avaliacoes
                .Include(a => a.Curso)
                .Include(a => a.Estudante)
                .Where(a => a.CursoId == cursoId)
                .ToListAsync();
        }

    }
}
