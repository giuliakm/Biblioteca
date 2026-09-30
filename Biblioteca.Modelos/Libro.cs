using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Modelos
{
    internal class Libro
    {
        [Key]
        public int IdLibro { get; set; }

        public string Titulo {  get; set; }

        public int AnioPublicacion { get; set; }

        public string ISBN { get; set; }

        public string Descripcion {  get; set; }

        // Llaves Foraneas
        public int IdAutor {  get; set; }

        public int IdGenero { get; set; }

        public int IdEditorial { get; set; }


    }
}
