using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoPostNetCore.Models
{
    [Table("producto")]
    public class Producto
    {
        [Key]
        [Column("codigo")]
        public int IdProducto { get; set; }

        [Column("nombre")]
        public string Nombre { get; set; }

        [Column("precio")]
        public int Precio { get; set; }

        [Column("codigo_fabricante")]
        public int IdFabricante { get; set; }
    }
}
