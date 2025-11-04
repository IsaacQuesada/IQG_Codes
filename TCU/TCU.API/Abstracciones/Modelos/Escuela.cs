using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstracciones.Modelos
{
    public class EscuelaBase
    {
        [Required(ErrorMessage = "El codigo del centro educativo es requerido")]
        [RegularExpression(@"^\d{4}$", ErrorMessage = "El formato del código debe ser de 4 números (####)")]
        public string Codigo { get; set; }
        [Required(ErrorMessage = "El nombre del centro educativo es requerido")]
        public string NombreCentroEducativo { get; set; }
        [Required(ErrorMessage = "El nombre del director (a) del centro educativo es requerido")]
        public string NombreDirector { get; set; }
    }

    public class EscuelaResponse : EscuelaBase
    {
        public Guid IdEscuela { get; set; }
    }
}
