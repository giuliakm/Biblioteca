using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Modelos
{
    internal class Editorial
    {
        [Key]
        public int IdEditorial { get; set; }

        public string NOmbre { get; set; }

        public string Pais {  get; set; }
    }
}
