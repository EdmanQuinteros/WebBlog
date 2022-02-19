using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BlogCore.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Required(ErrorMessage ="El nombre es obligatorio")]
        public string Nombre { get; set; }

        public string Direccion { get; set; }

        [Required(ErrorMessage = "La ciudad es obligatorio")]
        public string Ciudad { get; set; }

        [Required(ErrorMessage = "El país es obligatorio")]
        public string Pais { get; set; }
    }
}
