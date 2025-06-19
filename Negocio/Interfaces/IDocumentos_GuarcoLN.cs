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
        bool Crear_documentos(Documentos_Guarco pDocumentos_Guarco);

        List<Documentos_Guarco> ConsultarDocumentos();
        List<Documentos_Guarco> VerHoras();
        List<Documentos_Guarco> DocumentosElaboracion();
        List<Documentos_Guarco> DocumentosRevision();
        List<Documentos_Guarco> DocumentosAprobado();
        List<Documentos_Guarco> BusquedaCodigo(string pCodigo);
        List<Documentos_Guarco> VerDocumentos(int pID);

        bool Modificardocumentos(Documentos_Guarco pDocumentos_Guarco);

        bool Eliminar_documentos(int pID);

        List<Documentos_Guarco> BusquedaTipo(string pTipo);

        List<Documentos_Guarco> BusquedaArea(string pArea);

        List<Documentos_Guarco> BusquedaEstado(string pEstado);

        List<Documentos_Guarco> AprobacionCodigo(string pAproCodigo);

        List<Documentos_Guarco> AprobacionTipo(string pAproTipo);

        List<Documentos_Guarco> AprobacionArea(string pAproArea);
    }
}
