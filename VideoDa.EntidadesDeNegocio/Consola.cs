using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoDa.EntidadesDeNegocio
{
    public class Consola
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio")]
        [StringLength(30, ErrorMessage = "Máximo 30 caracteres")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "La descripcion es obligatoria")]
        [StringLength(500, ErrorMessage = "Máximo 500 caracteres")]
        public string Descripcion { get; set; }

        [Required(ErrorMessage = "La serie es obligatoria")]
        [StringLength(45, ErrorMessage = "Máximo 45 caracteres")]
        public string Serie { get; set; }

        [Required(ErrorMessage = "El fabricante es obligatorio")]
        [StringLength(40, ErrorMessage = "Máximo 40 caracteres")]
        public string Fabricante { get; set; }
        
             [Required(ErrorMessage = "Año de Lanzamiento es obligatorio")]
        [StringLength(500, ErrorMessage = "Máximo 500 caracteres")]
        public string Imagen { get; set; }

        [Required(ErrorMessage = "Año de Lanzamiento es obligatorio")]
        [StringLength(45, ErrorMessage = "Máximo 45 caracteres")]
        public string AñodeLanzamiento { get; set; }

        [NotMapped]
        public int Top_Aux { get; set; }

    }
}
