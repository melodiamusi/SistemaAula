using Microsoft.EntityFrameworkCore;
using SistemaAula.Domain.Entidades;

namespace SistemaAula.Infrastructure.Contexto
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Estudiante> Estudiantes { get; set; }

        public DbSet<Curso> Cursos { get; set; }

        public DbSet<Aula> Aulas { get; set; }

        
    }
}
