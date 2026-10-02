using Microsoft.EntityFrameworkCore;

public class BibliotecaAPIContext(DbContextOptions<BibliotecaAPIContext> options) : DbContext(options)
{
    public DbSet<Biblioteca.Modelos.Autor> Autores { get; set; } = default!;
    public DbSet<Biblioteca.Modelos.Editorial> Editoriales { get; set; } = default!;
    public DbSet<Biblioteca.Modelos.Genero> Generos { get; set; } = default!;
    public DbSet<Biblioteca.Modelos.Libro> Libros { get; set; } = default!;

}
