using Microsoft.AspNetCore.Mvc;
using Entidades.SqlServer;
using Negocio.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/Documentos_Guarco")] // usa kebab-case: api/documentos
    public class Documentos_GuarcoController : ControllerBase
    {
        private readonly IDocumentos_GuarcoLN _logic;

        public Documentos_GuarcoController(IDocumentos_GuarcoLN logic)
            => _logic = logic;

        [HttpPost("Crear_documentos")]
        public async Task<ActionResult<bool>> Crear_documentos([FromBody] Documentos_Guarco doc)
        {
            if (doc == null) return BadRequest("Documento requerido.");
            bool ok = await _logic.Crear_documentosAsync(doc);
            return ok ? Ok(true) : StatusCode(500, "Error al crear.");
        }

        [HttpGet("ConsultarDocumentos")]
        public async Task<ActionResult<List<Documentos_Guarco>>> ConsultarDocumentos()
        {
            var list = await _logic.ConsultarDocumentosAsync();
            return (list == null || list.Count == 0) ? NotFound() : Ok(list);
        }

        [HttpGet("VerDocumentos")]
        public async Task<ActionResult<Documentos_Guarco>> VerDocumento([FromHeader]int pID)
        {
            var doc = await _logic.VerDocumentosAsync(pID);
            return doc == null ? NotFound($"No existe {pID}") : Ok(doc);
        }

        [HttpPut("ModificarDocumentos")]
        public async Task<ActionResult<bool>> Modificar_documentos([FromBody] Documentos_Guarco doc)
        {
            if (doc == null) return BadRequest("Documento requerido.");
            bool ok = await _logic.Modificar_documentosAsync(doc);
            return ok ? Ok(true) : StatusCode(500, "Error al modificar.");
        }

        [HttpDelete("Eliminar_documentos")]
        public async Task<ActionResult<bool>> Eliminar_documentos([FromHeader]int pID)
        {
            bool ok = await _logic.Eliminar_documentosAsync(pID);
            return ok ? Ok(true) : StatusCode(500, "Error al eliminar.");
        }

      

        [HttpGet("VerHoras")]
        public async Task<ActionResult<List<Documentos_Guarco>>> VerHoras()
            => Ok(await _logic.VerHorasAsync());

        [HttpGet("DocumentosElaboracion")]
        public async Task<ActionResult<List<Documentos_Guarco>>> DocumentosElaboracion()
            => Ok(await _logic.DocumentosElaboracionAsync());

        [HttpGet("DocumentosRevision")]
        public async Task<ActionResult<List<Documentos_Guarco>>> DocumentosRevision()
            => Ok(await _logic.DocumentosRevisionAsync());

        [HttpGet("DocumentosAprobado")]
        public async Task<ActionResult<List<Documentos_Guarco>>> DocumentosAprobado()
            => Ok(await _logic.DocumentosAprobadoAsync());

        [HttpGet("BusquedaCodigo")]
        public async Task<ActionResult<List<Documentos_Guarco>>> BusquedaCodigo([FromHeader] string pCodigo)
        {
            if (string.IsNullOrWhiteSpace(pCodigo))
                return BadRequest("Parámetro 'codigo' requerido.");
            return Ok(await _logic.BusquedaCodigoAsync(pCodigo));
        }

        [HttpGet("AprobacionArea")]
        public async Task<ActionResult<List<Documentos_Guarco>>> AprobacionArea([FromHeader] string pAproArea)
        {
            var result = await _logic.AprobacionAreaAsync(pAproArea);
            return Ok(result);
        }
    }
}
