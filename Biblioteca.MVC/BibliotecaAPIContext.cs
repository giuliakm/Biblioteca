using Microsoft.EntityFrameworkCore;

public class BibliotecaAPIContext(DbContextOptions<BibliotecaAPIContext> options) : DbContext(options)
{
    public DbSet<Biblioteca.Modelos.Libro> Libro { get; set; } = default!;
}
