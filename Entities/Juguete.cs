using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace examen2Poo.Entities
{
    public class Juguete
    {
   
    public Guid Id { get; set; }
    [Key]
    
    public int Codigo { get; set; }
    [Required]

    
    public string Nombre { get; set; }
    [Required]
    [MaxLength(100)]

    
    public decimal Precio { get; set; }
    [Required]

    public DateTime? Vigencia { get; set; }
    [DataType(DataType.Date)]
    
    public bool Activo { get; set; }
    }

    //public List<Marca> Marcas { get; set;}
}