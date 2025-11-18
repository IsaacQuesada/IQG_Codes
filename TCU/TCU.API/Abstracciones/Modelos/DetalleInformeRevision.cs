using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstracciones.Modelos
{
    public class DetalleInformeRevisionBase
    {
        public bool Cumple { get; set; }
        public string Observacion { get; set; }
    }

    public class DetalleInformeRevisionRequest : DetalleInformeRevisionBase
    {
        public Guid IdInforme { get; set; }
        public Guid IdAspecto { get; set; }
    }

    public class DetalleInformeRevisionResponse : DetalleInformeRevisionBase
    {
        public Guid IdDetalleInforme { get; set; }
        public string NombreAspecto { get; set; }
    }

}
