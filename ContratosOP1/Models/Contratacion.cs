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

    [Table("Contratacion", Schema = "CT")]

    public partial class Contratacion
    {
        [Key]
        public int Id { get; set; }       
        [Required(ErrorMessage = "El campo {0} es obligatorio")]       
        [Display(Name = "Empleado")]
        public int EmpleadoId { get; set; }
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [Display(Name = "Cargo")]
        public int CargoId { get; set; }
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [Display(Name = "Salario")]
        public string Salario { get; set; }
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode =true,DataFormatString ="{0:dd-MM-yyyy}")]
        [Display(Name = "Fecha de Inicio")]
        public DateTime FechaInicio { get; set; }
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy}")]
        [Display(Name = "Fecha de Fin")]
        public DateTime FechaFin { get; set; }
        [Required(ErrorMessage = "El campo {0} es obligatorio")]        
        [Display(Name = "Activo")]
        public bool Activo { get; set; }
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [Display(Name = "Tipo de Contrato")]
        public int TipoDeContratoId { get; set; }
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [Display(Name = "Unidad")]
        public int UnidadId { get; set; }
    
        public virtual Empleado Empleado { get; set; }
        public virtual Cargo Cargo { get; set; }
        public virtual TipoDeContrato TipoDeContrato { get; set; }
        public virtual Unidad Unidad { get; set; }
    }
}