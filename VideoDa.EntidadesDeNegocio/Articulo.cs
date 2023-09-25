using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoDa.EntidadesDeNegocio
{
    public class Articulo
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Consola")]
        [Required(ErrorMessage = "La consola es obligatoria")]
        [Display(Name = "Consola")]
        public int IdConsola { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio")]
        [StringLength(30, ErrorMessage = "Máximo 30 caracteres")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "La descripcion es obligatoria")]
        [StringLength(500, ErrorMessage = "Máximo 500 caracteres")]
        public string Descripcion { get; set; }

        [Required(ErrorMessage = "La cantidad es obligatoria")]
        [StringLength(100, ErrorMessage = "Máximo 100 caracteres")]
        public string Cantidad { get; set; }

        [Required(ErrorMessage = "La Imagen es obligatoria")]
        [StringLength(500, ErrorMessage = "Máximo 500 caracteres")]
        public string Imagen { get; set; }

        [Required(ErrorMessage = "La Imagen es obligatoria")]
        [StringLength(500, ErrorMessage = "Máximo 500 caracteres")]
        public string Precio { get; set; }



        [NotMapped]
        public int Top_Aux { get; set; }


    }
}
