using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace examen2Poo.Entities
{
    public class Marca
    {
        
    public Guid Id { get; set; }
    [Key]
    
    public int Codigo { get; set; }
    [Required]
    
   
    public string Nombre { get; set; }
    [Required]
    [StringLength(100)]
    public bool Activo { get; set; }

    public Guid? Juguete { get; set; }
    public Marca? Marcas { get; set; }
    }
}