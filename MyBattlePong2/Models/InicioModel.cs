﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyBattlePong2.Models
{
    public class InicioModel
    {
        // Es el modelo básico de los datos de entrada de la forma.

        // Estas resricciones no son necesarias, pero este código está acá porque estoy haciendo
       // unas pruebas
        [Required]
        [StringLength(20, MinimumLength = 4, ErrorMessage = "Nombre muy corto")]
        public string Usuario { get; set; }

        // Restricciones de la contraseña
        [Required]
        [StringLength(18, MinimumLength = 1, ErrorMessage = "Contraseña muy corta")]
        public string Contrasena { get; set; }

    }
}