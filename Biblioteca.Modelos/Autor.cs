using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Modelos
{
    public class Autor
    {
        [Key]
        public int IdAutor { get; set; }

        public string Nombre { get; set; }

        public string Apellido { get; set; }
        
        public string Nacionalidad { get; set; }

        
    }
}
