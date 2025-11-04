using Abstracciones.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstracciones.Interfaces.DA
{
    public interface IAspectoEvaluarDA
    {
        Task<IEnumerable<AspectoEvaluarResponse>> Obtener();
        Task<AspectoEvaluarResponse> Obtener(Guid IdAspectoEvaluar);
        Task<Guid> Agregar(AspectoEvaluarRequest aspectoEvaluar);
        Task<Guid> Editar(Guid IdAspectoEvaluar, AspectoEvaluarRequest aspectoEvaluar);
        Task<Guid> Eliminar(Guid IdAspectoEvaluar);
    }
}
