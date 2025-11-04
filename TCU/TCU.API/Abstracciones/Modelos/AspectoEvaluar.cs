using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstracciones.Modelos
{
    public class AspectoEvaluarBase
    {
        public string Descripcion { get; set; }
        public bool Activo { get; set; }
    }
    public class AspectoEvaluarRequest : AspectoEvaluarBase
    {
        public Guid IdCategoria { get; set; }
    }
    public class AspectoEvaluarResponse : AspectoEvaluarBase
    {
        public Guid IdAspectoEvaluar { get; set; }
        public string NombreCategoria { get; set; }
    }
}
