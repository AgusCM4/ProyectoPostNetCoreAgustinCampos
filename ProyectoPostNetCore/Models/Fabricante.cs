using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoPostNetCore.Models
{
    [Table("fabricante")]
    public class Fabricante
    {
        [Key]
        [Column("codigo")]
        public int IdFabricante { get; set; }

        [Column("nombre")]
        public string Nombre { get; set; }
    }
}
