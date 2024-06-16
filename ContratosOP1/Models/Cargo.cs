
namespace ContratosOP1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Xml.Serialization;

    [Table("Cargo",Schema="CT")]
    
    public partial class Cargo
    {
        public Cargo()
        {
            this.Contratacion = new HashSet<Contratacion>();
        }
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage ="El campo {0} es obligatorio")]
        [StringLength(5,ErrorMessage ="Longiturd maxima 5 caracteres")]
        [Display(Name ="Codigo de Cargo")]
        public string Codigo { get; set; }
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [StringLength(30, ErrorMessage = "Longiturd maxima 30 caracteres")]
        [Display(Name = "Nombre de Cargo")]
        public string Descripcion { get; set; }
    
        public virtual ICollection<Contratacion> Contratacion { get; set; }
    }
}
