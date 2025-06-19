using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccesoDatos.Interfaces;
using Entidades.SqlServer;
using Negocio.Interfaces;

namespace Negocio
{
    public class Documentos_GuarcoLN : IDocumentos_GuarcoLN
    {
        private IDocumentos_GuarcoAD _iDocumentos_GuarcoAD;

        public Documentos_GuarcoLN(IDocumentos_GuarcoAD iDocumentos_GuarcoAD)
        {
            _iDocumentos_GuarcoAD = iDocumentos_GuarcoAD;
        }
        public bool Crear_documentos(Documentos_Guarco pDocumentos_Guarco)
        {
            return _iDocumentos_GuarcoAD.Crear_documentos(pDocumentos_Guarco);
        }
        public List<Documentos_Guarco>ConsultarDocumentos()
        {
            return _iDocumentos_GuarcoAD.ConsultarDocumentos();
        }
        public List<Documentos_Guarco> VerHoras()
        {
            return _iDocumentos_GuarcoAD.VerHoras();
        }

        public List<Documentos_Guarco> DocumentosElaboracion()
        {
            return _iDocumentos_GuarcoAD.DocumentosElaboracion();
        }
        public List<Documentos_Guarco> DocumentosRevision()
        {
            return _iDocumentos_GuarcoAD.DocumentosRevision();
        }
        public List<Documentos_Guarco> DocumentosAprobado()
        {
            return _iDocumentos_GuarcoAD.DocumentosAprobado();
        }
        public List<Documentos_Guarco> BusquedaCodigo(string pCodigo)
        {
            return _iDocumentos_GuarcoAD.BusquedaCodigo(pCodigo);
        }
        public List<Documentos_Guarco> VerDocumentos(int pID)
        {
            return _iDocumentos_GuarcoAD.VerDocumentos(pID);
        }

        public bool Modificardocumentos(Documentos_Guarco pDocumentos_Guarco)
        {
            return _iDocumentos_GuarcoAD.Modificardocumentos(pDocumentos_Guarco);
        }

        public bool Eliminar_documentos(int pID)
        {
            return _iDocumentos_GuarcoAD.Eliminar_documentos(pID);
        }

        public List<Documentos_Guarco> BusquedaTipo(string pTipo)
        {
            return _iDocumentos_GuarcoAD.BusquedaTipo(pTipo);
        }

        public List<Documentos_Guarco> BusquedaArea(string pArea)
        {
            return _iDocumentos_GuarcoAD.BusquedaArea(pArea);
        }

        public List<Documentos_Guarco> BusquedaEstado(string pEstado)
        {
            return _iDocumentos_GuarcoAD.BusquedaEstado(pEstado);
        }
        public List<Documentos_Guarco> AprobacionCodigo(string pAproCodigo)
        {
            return _iDocumentos_GuarcoAD.AprobacionCodigo(pAproCodigo);
        }

        public List<Documentos_Guarco> AprobacionTipo(string pAproTipo)
        {
            return _iDocumentos_GuarcoAD.AprobacionTipo(pAproTipo);
        }

        public List<Documentos_Guarco> AprobacionArea(string pAproArea)
        {
            return _iDocumentos_GuarcoAD.AprobacionArea(pAproArea);
        }
    }
}
