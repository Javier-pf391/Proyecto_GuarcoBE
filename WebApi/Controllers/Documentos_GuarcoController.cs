using Microsoft.AspNetCore.Mvc;
using Entidades.SqlServer;
using Negocio.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/documentos")] // usa kebab-case: api/documentos
    public class Documentos_GuarcoController : ControllerBase
    {
        private readonly IDocumentos_GuarcoLN _logic;

        public Documentos_GuarcoController(IDocumentos_GuarcoLN logic)
            => _logic = logic;

        [HttpPost]
        public async Task<ActionResult<bool>> Crear_documentos([FromBody] Documentos_Guarco doc)
        {
            if (doc == null) return BadRequest("Documento requerido.");
            bool ok = await _logic.Crear_documentosAsync(doc);
            return ok ? Ok(true) : StatusCode(500, "Error al crear.");
        }

        [HttpGet]
        public async Task<ActionResult<List<Documentos_Guarco>>> ConsultarDocumentos()
        {
            var list = await _logic.ConsultarDocumentosAsync();
            return (list == null || list.Count == 0) ? NotFound() : Ok(list);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Documentos_Guarco>> VerDocumento(int id)
        {
            var doc = await _logic.VerDocumentosAsync(id);
            return doc == null ? NotFound($"No existe {id}") : Ok(doc);
        }

        [HttpPut]
        public async Task<ActionResult<bool>> Modificar_documentos([FromBody] Documentos_Guarco doc)
        {
            if (doc == null) return BadRequest("Documento requerido.");
            bool ok = await _logic.Modificar_documentosAsync(doc);
            return ok ? Ok(true) : StatusCode(500, "Error al modificar.");
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<bool>> Eliminar_documentos(int id)
        {
            bool ok = await _logic.Eliminar_documentosAsync(id);
            return ok ? Ok(true) : StatusCode(500, "Error al eliminar.");
        }

        // Endpoints adicionales

        [HttpGet("horas")]
        public async Task<ActionResult<List<Documentos_Guarco>>> VerHoras()
            => Ok(await _logic.VerHorasAsync());

        [HttpGet("elaboracion")]
        public async Task<ActionResult<List<Documentos_Guarco>>> DocumentosElaboracion()
            => Ok(await _logic.DocumentosElaboracionAsync());

        [HttpGet("revision")]
        public async Task<ActionResult<List<Documentos_Guarco>>> DocumentosRevision()
            => Ok(await _logic.DocumentosRevisionAsync());

        [HttpGet("aprobado")]
        public async Task<ActionResult<List<Documentos_Guarco>>> DocumentosAprobado()
            => Ok(await _logic.DocumentosAprobadoAsync());

        [HttpGet("buscar")]
        public async Task<ActionResult<List<Documentos_Guarco>>> BusquedaCodigo([FromQuery] string codigo)
        {
            if (string.IsNullOrWhiteSpace(codigo))
                return BadRequest("Parámetro 'codigo' requerido.");
            return Ok(await _logic.BusquedaCodigoAsync(codigo));
        }

        [HttpGet("aprobacion-area")]
        public async Task<ActionResult<List<Documentos_Guarco>>> AprobacionArea([FromQuery] string area = "")
        {
            var result = await _logic.AprobacionAreaAsync(area);
            return Ok(result);
        }
    }
}
