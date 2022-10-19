using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Producto
    {
        // Propiedades/Atributos de la tabla Producto de la BD
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public int Existencia { get; set; }
        public decimal Precio { get; set; }
        public DateTime FechaCreacion { get; set; }
        public byte[] Imagen { get; set; }
    }
}
