using System;

namespace Abstracciones.Modelos
{
    public class InformeRevisionBase
    {
        public DateTime Fecha { get; set; }
        public string ObservacionGeneral { get; set; }
    }

    public class InformeRevisionRequest : InformeRevisionBase
    {
        public Guid IdEscuela { get; set; }
    }

    public class InformeRevisionResponse : InformeRevisionBase
    {
        public Guid IdInforme { get; set; }
        public string NombreCentroEducativo { get; set; }
    }
}
