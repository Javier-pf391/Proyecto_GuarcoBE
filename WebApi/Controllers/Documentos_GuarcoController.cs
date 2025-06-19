using Microsoft.AspNetCore.Mvc;
using Entidades.SqlServer;
using Negocio.Interfaces;


namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/Documentos_Guarco")]
    public class Documentos_GuarcoController : Controller
    {
        private readonly IDocumentos_GuarcoLN _iDocumentos_GuarcoLN;

        public Documentos_GuarcoController(IDocumentos_GuarcoLN iDocumentos_GuarcoLN)
        {
            _iDocumentos_GuarcoLN = iDocumentos_GuarcoLN;
        }
        [HttpPost]
        [Route(nameof(Crear_documentos))]
        public bool Crear_documentos([FromBody] Documentos_Guarco pDocumentos_Guarco)
        {
            return _iDocumentos_GuarcoLN.Crear_documentos(pDocumentos_Guarco);
        }
        [HttpGet]
        [Route(nameof(ConsultarDocumentos))]
        public List<Documentos_Guarco> ConsultarDocumentos()
        {
            return _iDocumentos_GuarcoLN.ConsultarDocumentos();
        }
        [HttpGet]
        [Route(nameof(VerHoras))]
        public List<Documentos_Guarco> VerHoras()
        {
            return _iDocumentos_GuarcoLN.VerHoras();
        }

        [HttpGet]
        [Route(nameof(DocumentosElaboracion))]
        public List<Documentos_Guarco> DocumentosElaboracion()
        {
            return _iDocumentos_GuarcoLN.DocumentosElaboracion();
        }
        [HttpGet]
        [Route(nameof(DocumentosRevision))]
        public List<Documentos_Guarco> DocumentosRevision()
        {
            return _iDocumentos_GuarcoLN.DocumentosRevision();
        }
        [HttpGet]
        [Route(nameof(DocumentosAprobado))]
        public List<Documentos_Guarco> DocumentosAprobado()
        {
            return _iDocumentos_GuarcoLN.DocumentosAprobado();
        }

        [HttpGet]
        [Route(nameof(BusquedaCodigo))]
        public List<Documentos_Guarco> BusquedaCodigo([FromHeader] string pCodigo)
        {
            return _iDocumentos_GuarcoLN.BusquedaCodigo(pCodigo);
        }
        [HttpGet]
        [Route(nameof(VerDocumentos))]
        public List<Documentos_Guarco> VerDocumentos([FromHeader] int pID)
        {
            return _iDocumentos_GuarcoLN.VerDocumentos(pID);
        }

        [HttpPut]
        [Route(nameof(Modificardocumentos))]
        public bool Modificardocumentos([FromBody]Documentos_Guarco pDocumentos_Guarco)
        {
            return _iDocumentos_GuarcoLN.Modificardocumentos(pDocumentos_Guarco);
        }
       
        [HttpDelete]
        [Route(nameof(Eliminar_documentos))]
        public bool Eliminar_documentos([FromHeader] int pID)
        {
            return _iDocumentos_GuarcoLN.Eliminar_documentos(pID);
        }


        [HttpGet]
        [Route(nameof(BusquedaTipo))]
        public List<Documentos_Guarco> BusquedaTipo([FromHeader] string pTipo)
        {
            return _iDocumentos_GuarcoLN.BusquedaTipo(pTipo);
        }

        [HttpGet]
        [Route(nameof(BusquedaArea))]
        public List<Documentos_Guarco> BusquedaArea([FromHeader] string pArea)
        {
            return _iDocumentos_GuarcoLN.BusquedaArea(pArea);
        }

        [HttpGet]
        [Route(nameof(BusquedaEstado))]
        public List<Documentos_Guarco> BusquedaEstado([FromHeader] string pEstado)
        {
            return _iDocumentos_GuarcoLN.BusquedaEstado(pEstado);
        }

        [HttpGet]
        [Route(nameof(AprobacionCodigo))]
        public List<Documentos_Guarco> AprobacionCodigo([FromHeader] string pAproCodigo)
        {
            return _iDocumentos_GuarcoLN.AprobacionCodigo(pAproCodigo);
        }

        [HttpGet]
        [Route(nameof(AprobacionTipo))]
        public List<Documentos_Guarco> AprobacionTipo([FromHeader] string pAproTipo)
        {
            return _iDocumentos_GuarcoLN.AprobacionTipo(pAproTipo);
        }

        [HttpGet]
        [Route(nameof(AprobacionArea))]
        public List<Documentos_Guarco> AprobacionArea([FromHeader] string pAproArea)
        {
            return _iDocumentos_GuarcoLN.AprobacionArea(pAproArea);
        }

    }
}
