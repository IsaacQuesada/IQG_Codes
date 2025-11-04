using Abstracciones.Interfaces.DA;
using Abstracciones.Interfaces.Flujo;
using Abstracciones.Modelos;

namespace Flujo
{
    public class EscuelaFlujo : IEscuelaFlujo
    {
        private IEscuelaDA _escuelaDA;

        public EscuelaFlujo(IEscuelaDA escuelaDA)
        {
            _escuelaDA = escuelaDA;
        }

        public async Task<Guid> Agregar(EscuelaBase escuela)
        {
            return await _escuelaDA.Agregar(escuela);
        }

        public async Task<Guid> Editar(Guid IdEscuela, EscuelaBase escuela)
        {
            return await _escuelaDA.Editar(IdEscuela, escuela);
        }

        public async Task<Guid> Eliminar(Guid IdEscuela)
        {
            return await _escuelaDA.Eliminar(IdEscuela);
        }

        public async Task<IEnumerable<EscuelaResponse>> Obtener()
        {
            return await _escuelaDA.Obtener();
        }

        public async Task<EscuelaResponse> Obtener(Guid IdEscuela)
        {
            return await _escuelaDA.Obtener(IdEscuela);
        }
    }
}
