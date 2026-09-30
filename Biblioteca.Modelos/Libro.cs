using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Modelos
{
    [Table("libro")]
    public class Libro
    {
        [Key]
        [Column("id_libro")]
        public int IdLibro { get; set; }

        [Column("titulo")]
        [MaxLength(150)]
        [Required]
        public string Titulo {  get; set; }

        [Column("anio_publicacion")]
        public int AnioPublicacion { get; set; }

        [Column("isbn")]
        [MaxLength(20)]
        public string ISBN { get; set; }

        [Column("descripcion")]
        [MaxLength(500)]
        public string Descripcion {  get; set; }

        // Llaves Foraneas
        [Column("id_autor")]
        public int IdAutor {  get; set; }

        [Column("id_genero")]
        public int IdGenero { get; set; }

        [Column("id_editorial")]
        public int IdEditorial { get; set; }

        // Objeto de Navegacion
        public Autor? Autor { get; set; }

        public Genero? Genero { get; set; }

        public Editorial? Editorial { get; set; }

        // Relacion

        public List<Ejemplar> Ejemplar { get; set; } = new List<Ejemplar>();


    }
}
