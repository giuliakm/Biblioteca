using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Modelos
{
    [Table("autor")]
    public class Autor
    {
        [Key]
        [Column("id_autor")]
        public int IdAutor { get; set; }

        [Column("nombre")]
        [MaxLength(50)]
        [Required]
        public string Nombre { get; set; }

        [Column("apellido")]
        [MaxLength(50)]
        [Required]
        public string Apellido { get; set; }

        [Column("nacionalidad")]
        [MaxLength(50)]
        public string Nacionalidad { get; set; }

        // Relacion

        public List<Libro> Libros { get; set; } = new List<Libro>();

        
    }
}
