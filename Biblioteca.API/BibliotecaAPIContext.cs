using Microsoft.EntityFrameworkCore;

public class BibliotecaAPIContext(DbContextOptions<BibliotecaAPIContext> options) : DbContext(options)
{
    public DbSet<Biblioteca.Modelos.Autor> Autor { get; set; } = default!;
    public DbSet<Biblioteca.Modelos.Editorial> Editorial { get; set; } = default!;
    public DbSet<Biblioteca.Modelos.Genero> Genero { get; set; } = default!;
    public DbSet<Biblioteca.Modelos.Libro> Libro { get; set; } = default!;

}
