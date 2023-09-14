﻿using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using NSwag.Annotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoDa.EntidadesDeNegocio
{
    public class Categoria
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Nombre es obligatorio")]
        [StringLength(30, ErrorMessage = "Maximo 30 caracteres")]
        public string Nombre { get; set; }

        [NotMapped]
        public int Top_Aux { get; set; }
        [ValidateNever]
        public List<Producto> Producto { get; set; }
    }
}
