using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Modelos
{
    [Table("editorial")]
    public class Editorial
    {
        [Key]
        [Column("id_editorial", TypeName = "serial")]
        public int IdEditorial { get; set; }

        [Column("nombre")]
        [MaxLength(50)]
        [Required]
        public string Nombre { get; set; }

        [Column("pais")]
        [MaxLength(50)]
        public string Pais {  get; set; }

        // Relacion
        public List<Libro> Libro { get; set; } = new List<Libro>();
    }
}
