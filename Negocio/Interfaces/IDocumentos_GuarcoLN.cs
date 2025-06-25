using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades.SqlServer;

namespace Negocio.Interfaces
{
    public interface IDocumentos_GuarcoLN
    {
        Task<bool> Crear_documentosAsync(Documentos_Guarco doc);
        Task<List<Documentos_Guarco>> ConsultarDocumentosAsync();
        Task<List<Documentos_Guarco>> VerHorasAsync();
        Task<List<Documentos_Guarco>> DocumentosElaboracionAsync();
        Task<List<Documentos_Guarco>> DocumentosRevisionAsync();
        Task<List<Documentos_Guarco>> DocumentosAprobadoAsync();
        Task<List<Documentos_Guarco>> BusquedaCodigoAsync(string pCodigo);
        Task<List<Documentos_Guarco>> VerDocumentosAsync(int id);
        Task<bool> Modificar_documentosAsync(Documentos_Guarco doc);
        Task<bool> Eliminar_documentosAsync(int id);
        Task<List<Documentos_Guarco>> AprobacionAreaAsync(string pAproArea);
    }
}
