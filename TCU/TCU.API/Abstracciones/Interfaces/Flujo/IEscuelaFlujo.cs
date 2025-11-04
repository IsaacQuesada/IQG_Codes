using Abstracciones.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstracciones.Interfaces.Flujo
{
    public interface IEscuelaFlujo
    {
        Task<IEnumerable<EscuelaResponse>> Obtener();
        Task<EscuelaResponse> Obtener(Guid IdEscuela);
        Task<Guid> Agregar(EscuelaBase escuela);
        Task<Guid> Editar(Guid IdEscuela, EscuelaBase escuela);
        Task<Guid> Eliminar(Guid IdEscuela);
    }
}
