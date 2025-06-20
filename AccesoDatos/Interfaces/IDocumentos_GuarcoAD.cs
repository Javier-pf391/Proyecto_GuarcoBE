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
        bool Crear_documentos(Documentos_Guarco pDocumentos_Guarco);
        List<Documentos_Guarco> BusquedaCodigo(string pCodigo);
        List<Documentos_Guarco> VerDocumentos(int pID);
        List<Documentos_Guarco> ConsultarDocumentos();
        List<Documentos_Guarco> VerHoras();

        List<Documentos_Guarco> DocumentosElaboracion();
        List<Documentos_Guarco> DocumentosRevision();
        List<Documentos_Guarco> DocumentosAprobado();
        bool Modificardocumentos(Documentos_Guarco pDocumentos_Guarco);

        bool Eliminar_documentos(int pID);

        List<Documentos_Guarco> AprobacionArea(string pAproArea);
    }
}
