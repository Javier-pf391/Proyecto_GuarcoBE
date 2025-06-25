using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AccesoDatos.Interfaces;
using Entidades.SqlServer;
using Negocio.Interfaces;

namespace Negocio
{
    public class Documentos_GuarcoLN : IDocumentos_GuarcoLN
    {
        private readonly IDocumentos_GuarcoAD _repo;

        public Documentos_GuarcoLN(IDocumentos_GuarcoAD repo)
        {
            _repo = repo;
        }

        public async Task<bool> Crear_documentosAsync(Documentos_Guarco doc)
        {
            return await _repo.Crear_documentosAsync(doc);
        }
           

        public async Task<List<Documentos_Guarco>> ConsultarDocumentosAsync()
        {
            var resultado = await _repo.ConsultarDocumentosAsync().ConfigureAwait(false);
            return resultado.ToList();
        }

        public async Task<List<Documentos_Guarco>> VerHorasAsync()
        {
            var resultado = await _repo.VerHorasAsync().ConfigureAwait(false);
            return resultado.ToList();
        }

        public async Task<List<Documentos_Guarco>> DocumentosElaboracionAsync()
        {
            var r = await _repo.DocumentosElaboracionAsync().ConfigureAwait(false);
            return r.ToList();
        }

        public async Task<List<Documentos_Guarco>> DocumentosRevisionAsync()
        {
            var r = await _repo.DocumentosRevisionAsync().ConfigureAwait(false);
            return r.ToList();
        }

        public async Task<List<Documentos_Guarco>> DocumentosAprobadoAsync()
        {
            var r = await _repo.DocumentosAprobadoAsync().ConfigureAwait(false);
            return r.ToList();
        }

        public async Task<List<Documentos_Guarco>> BusquedaCodigoAsync(string pCodigo)
        {
            var r = await _repo.BusquedaCodigoAsync(pCodigo).ConfigureAwait(false);
            return r.ToList();
        }

        public async Task<List<Documentos_Guarco>> VerDocumentosAsync(int id)
        {
            var r = await _repo.VerDocumentosAsync(id).ConfigureAwait(false);
            return r.ToList();
        }
           

        public async Task<bool> Modificar_documentosAsync(Documentos_Guarco doc)
        {
            var r = await _repo.Modificar_documentosAsync(doc).ConfigureAwait(false);
            return r;
        }
           

        public async Task<bool> Eliminar_documentosAsync(int id)
        {
            return await _repo.Eliminar_documentosAsync(id);
        }
           

        public async Task<List<Documentos_Guarco>> AprobacionAreaAsync(string area)
        {
            var r = await _repo.AprobacionAreaAsync(area).ConfigureAwait(false);
            return r.ToList();
        }
    }
}
