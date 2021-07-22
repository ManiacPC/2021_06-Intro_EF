using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Intro_EF.Models
{
    [Table("usuario")] // definimos la tabla usuario
    public class Usuario
    {
        public int id { get; set; }
        public string username { get; set; }
        public string password { get; set; }

        // relationships
        public ICollection<Venta> Ventas { get; set; }
    }

    [Table("venta")]
    public class Venta
    {
        public int id { get; set; }
        public int usuario_id { get; set; }
        public int total { get; set; }
        public DateTime fecha { get; set; }
        
        // Relationships
        public Usuario Usuario { get; set; }

    }
}