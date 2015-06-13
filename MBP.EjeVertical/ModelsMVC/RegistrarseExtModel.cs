using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MBP.CapaTransversal.ModelsMVC
{
    public class RegistrarseExtModel 
    {

        [Required]
        [StringLength(20, MinimumLength = 1, ErrorMessage = "Pais No Válido")]
        public string Pais { get; set; }

        [Required]
        public string Genero { get; set; }

        public string FechaNacimiento { get; set; }
        public string Foto { get; set; }

    }
}