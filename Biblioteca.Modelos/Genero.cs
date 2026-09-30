using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Modelos
{
    internal class Genero
    {
        [Key]
        public int IdGenero { get; set; }

        public string Nombre { get; set; }
    }
}
