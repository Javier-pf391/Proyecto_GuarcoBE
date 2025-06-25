using System;
using Entidades.SqlServer;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos.Interfaces
{
    public interface IDocumentos_GuarcoAD
    {
        Task<bool> Crear_documentosAsync(Documentos_Guarco pDocumentos_Guarco);
        Task<List<Documentos_Guarco>> ConsultarDocumentosAsync();
        Task<List<Documentos_Guarco>> VerHorasAsync();
        Task<List<Documentos_Guarco>> DocumentosElaboracionAsync();
        Task<List<Documentos_Guarco>> DocumentosRevisionAsync();
        Task<List<Documentos_Guarco>> DocumentosAprobadoAsync();
        Task<List<Documentos_Guarco>> BusquedaCodigoAsync(string pCodigo);
        Task<List<Documentos_Guarco>> VerDocumentosAsync(int pID);
        Task<bool> Modificar_documentosAsync(Documentos_Guarco pDocumentos_Guarco);
        Task<bool> Eliminar_documentosAsync(int pID);
        Task<List<Documentos_Guarco>> AprobacionAreaAsync(string pAproArea);
    }
}
