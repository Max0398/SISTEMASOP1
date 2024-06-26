//------------------------------------------------------------------------------
// <auto-generated>
//    Este código se generó a partir de una plantilla.
//
//    Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//    Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ContratosOP1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Departamento", Schema = "CT")]
    public partial class Departamento
    {
        public Departamento()
        {
            this.Municipio = new HashSet<Municipio>();
        }

        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [StringLength(5, ErrorMessage = "Longiturd maxima 5 caracteres")]
        [Display(Name = "Codigo de Cargo")]
        public string Codigo { get; set; }
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [StringLength(40, ErrorMessage = "Longiturd maxima 30 caracteres")]
        [Display(Name = "Departamento")]
        public string Descripcion { get; set; }
    
        public virtual ICollection<Municipio> Municipio { get; set; }
    }
}
