using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace examen2Poo.Models
{
    public class JugueteModel
    {
    public Guid Id { get; set; }
    
    public int Codigo { get; set; }

    public string Nombre { get; set; }

    public decimal Precio { get; set; }

    //public DateTime? Vigencia { get; set; }
    //public bool Activo { get; set; }
    }
    
}