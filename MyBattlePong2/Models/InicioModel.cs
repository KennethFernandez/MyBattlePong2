using System.ComponentModel.DataAnnotations;

namespace MyBattlePong2.Models
{
    public class InicioModel
    {
        // Es el modelo básico de los datos de entrada de la forma.

        // Estas resricciones no son necesarias, pero este código está acá porque estoy haciendo
       // unas pruebas
        [Required]
        [StringLength(20, MinimumLength = 1, ErrorMessage = "Usuario incorrecto")]
        public string Usuario { get; set; }

        // Restricciones de la contraseña
        [Required]
        [StringLength(8, MinimumLength = 4, ErrorMessage = "Contraseña incorrecta")]
        public string Contrasena { get; set; }

    }
}