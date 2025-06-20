using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.SqlServer
{
   

    public class Documentos_Guarco
    {
        public int id_documento { get; set; }

        public string codigo { get; set; }

        public string nombre { get; set; }

        public string tipo  { get; set;}

        public string nombre_area { get; set; }

        public string documento { get; set; }

        public string estado { get; set; }

        public DateTime? Fecha_inicio { get; set; }

        public DateTime? Fecha_finalizacion { get; set; }

        public DateTime? Fecha_revision_inicio { get; set; }

        public DateTime? Fecha_revision_finalizacion { get; set; }

        public DateTime? Fecha_aprobacion { get; set; }

        public Documentos_Guarco()
        {
            id_documento = 0;
            codigo = string.Empty;
            nombre = string.Empty;
            tipo = string.Empty;
            documento = string.Empty;
            nombre_area = string.Empty;
            estado = string.Empty;
            Fecha_inicio = null;
            Fecha_finalizacion = null;
            Fecha_revision_inicio = null;
            Fecha_revision_finalizacion = null;
            Fecha_aprobacion =  null;
        }

    }
}
