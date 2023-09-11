using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoDa.EntidadesDeNegocio
{
    public class Empleado
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Rol")]
        [Required(ErrorMessage = "El Rol es obligatorio")]
        [Display(Name = "Rol")]
        public int IdRol { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio")]
        [StringLength(30, ErrorMessage = "Máximo 30 caracteres")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El apellido es obligatorio")]
        [StringLength(30, ErrorMessage = "Máximo 30 caracteres")]
        public string Apellido { get; set; }

        [Required(ErrorMessage = "La edad es obligatorio")]
        [StringLength(5, ErrorMessage = "Máximo 30 caracteres")]
        public string Edad { get; set; }

        [Required(ErrorMessage = "El telefono es obligatorio")]
        [StringLength(30, ErrorMessage = "Máximo 30 caracteres")]
        public string Telefono { get; set; }


        [Required(ErrorMessage = "El DUI es obligatorio")]
        [StringLength(30, ErrorMessage = "Máximo 30 caracteres")]
        public string Dui { get; set; }

        [Required(ErrorMessage = "El correo es obligatorio")]
        [StringLength(30, ErrorMessage = "Máximo 30 caracteres")]
        public string Correo { get; set; }

        [Required(ErrorMessage = "La direccion es obligatoria")]
        [StringLength(30, ErrorMessage = "Máximo 30 caracteres")]
        public string Direccion { get; set; }

        [Required(ErrorMessage = "El departamento es obligatorio")]
        [StringLength(30, ErrorMessage = "Máximo 30 caracteres")]
        public string Departamento { get; set; }

        [NotMapped]
        public int Top_Aux { get; set; }

    }
}
