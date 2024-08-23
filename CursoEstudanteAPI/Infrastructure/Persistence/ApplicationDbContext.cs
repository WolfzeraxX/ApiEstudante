using CursoEstudanteAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CursoEstudanteAPI.Infrastructure.Persistence
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Curso> Cursos { get; set; }
        public DbSet<Estudante> Estudantes { get; set; }
        public DbSet<Avaliacao> Avaliacoes { get; set; }
    }
}
