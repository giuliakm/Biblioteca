using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Modelos
{
    [Table("ejemplar")]
    internal class Ejemplar
    {
       
        [Column("id_libro")]
        public int IdLibro { get; set; }
        public Libro? Libro { get; set; }

        [Column("numero_ejemplar")]
        public int NroEjemplar { get; set; }

        [Column("estado")]
        [MaxLength(30)]
        [Required]
        public string Estado { get; set; }

        
    }
}
