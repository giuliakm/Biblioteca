using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Modelos
{
    [Table("genero")]
    public class Genero
    {
        [Key]
        [Column("id_genero")]
        public int IdGenero { get; set; }

        [Column("nombre")]
        [MaxLength(50)]
        [Required]
        public string Nombre { get; set; }

        // Relacion
        public List<Libro> Libro { get; set; } = new List<Libro>();
    }
}
