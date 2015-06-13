using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MBP.CapaTransversal.ModelsMVC
{
    public class RegistrarseModel
    {
        public int tipo { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 1, ErrorMessage = "UserName No Válido")]
        public string Login { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 1, ErrorMessage = "Password No Válido")]
        public string Password { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 1, ErrorMessage = "Password No Válido")]
        public string PasswordConf { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 1, ErrorMessage = "Nombre no Válido")]
        public string Nombre { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 1, ErrorMessage = "Apellido no Válido")]
        public string Apellido { get; set; }

        [Required]
        [EmailAddress]
        [StringLength(40, MinimumLength = 1, ErrorMessage = "E-Correo no Válido")]
        public string Email { get; set; }
        [Required]
        public string Tipo {get; set; }
    }
}