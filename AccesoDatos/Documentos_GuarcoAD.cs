using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AccesoDatos.Interfaces;
using Entidades.SqlServer;
using Dapper;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;

namespace AccesoDatos
{
    public class Documentos_GuarcoAD : IDocumentos_GuarcoAD
    {
        private readonly IConfiguration _IConfiguration;

        public Documentos_GuarcoAD(IConfiguration iConfiguration)
        {
            _IConfiguration = iConfiguration;
        }

        public bool Crear_documentos(Documentos_Guarco pDocumentos_Guarco)
        {
            DynamicParameters parameters = new DynamicParameters();

            parameters.Add("@Codigo", pDocumentos_Guarco.codigo, DbType.String, ParameterDirection.Input);
            parameters.Add("@Nombre", pDocumentos_Guarco.nombre, DbType.String, ParameterDirection.Input);
            parameters.Add("@Tipo", pDocumentos_Guarco.tipo, DbType.String, ParameterDirection.Input);
            parameters.Add("@Documento", pDocumentos_Guarco.documento, DbType.String, ParameterDirection.Input);
            parameters.Add("@Nombre_area", pDocumentos_Guarco.nombre_area, DbType.String, ParameterDirection.Input);
            parameters.Add("@Estado", pDocumentos_Guarco.estado, DbType.String, ParameterDirection.Input);
            parameters.Add("@Fecha_inicio", pDocumentos_Guarco.Fecha_inicio, DbType.DateTime, ParameterDirection.Input);
            parameters.Add("@Fecha_finalizacion", pDocumentos_Guarco.Fecha_finalizacion, DbType.DateTime, ParameterDirection.Input);
            parameters.Add("@Fecha_revision_inicio", pDocumentos_Guarco.Fecha_revision_inicio, DbType.DateTime, ParameterDirection.Input);
            parameters.Add("@Fecha_revision_finalizacion", pDocumentos_Guarco.Fecha_revision_finalizacion, DbType.DateTime, ParameterDirection.Input);
            parameters.Add("@Fecha_aprobacion", pDocumentos_Guarco.Fecha_aprobacion, DbType.DateTime, ParameterDirection.Input);

            using (var conexion_SQL = new SqlConnection(_IConfiguration.GetConnectionString("ConexionSQLServer")))
            {
                return conexion_SQL.Execute("PA_Agregardocumentos", parameters, commandType: CommandType.StoredProcedure) > 0;
            }
        }

        public List<Documentos_Guarco> ConsultarDocumentos()
        {
            using (var ConexionSQL = new SqlConnection(_IConfiguration.GetConnectionString("ConexionSQLServer")))
            {
                return ConexionSQL.Query<Documentos_Guarco>(
                    "PA_ConsultarDocumentos",
                    commandType: CommandType.StoredProcedure
                ).ToList();
            }
        }
        public List<Documentos_Guarco> VerHoras()
        {
            using (var ConexionSQL = new SqlConnection(_IConfiguration.GetConnectionString("ConexionSQLServer")))
            {
                return ConexionSQL.Query<Documentos_Guarco>(
                    "PA_VerHoras",
                    commandType: CommandType.StoredProcedure
                ).ToList();
            }
        }

        public List<Documentos_Guarco> BusquedaCodigo(string pCodigo)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@Codigo", pCodigo, DbType.String, ParameterDirection.Input);
            using (var ConexionSQL = new SqlConnection(_IConfiguration.GetConnectionString("ConexionSQLServer")))
            {
                return (List<Documentos_Guarco>)ConexionSQL.Query<Documentos_Guarco>("PA_Consultarcodigo", parameters, commandType: CommandType.StoredProcedure);
            }
        }
        public List<Documentos_Guarco> VerDocumentos(int pID)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@id_documento", pID, DbType.String, ParameterDirection.Input);
            using (var ConexionSQL = new SqlConnection(_IConfiguration.GetConnectionString("ConexionSQLServer")))
            {
                return (List<Documentos_Guarco>)ConexionSQL.Query<Documentos_Guarco>("PA_VerDocumentos", parameters, commandType: CommandType.StoredProcedure);
            }
        }
        public List<Documentos_Guarco> DocumentosElaboracion()
        {
            using (var ConexionSQL = new SqlConnection(_IConfiguration.GetConnectionString("ConexionSQLServer")))
            {
                return ConexionSQL.Query<Documentos_Guarco>(
                    "PA_DocumentosElaboracion",
                    commandType: CommandType.StoredProcedure
                ).ToList();
            }
        }
        public List<Documentos_Guarco> DocumentosRevision()
        {
            using (var ConexionSQL = new SqlConnection(_IConfiguration.GetConnectionString("ConexionSQLServer")))
            {
                return ConexionSQL.Query<Documentos_Guarco>(
                    "PA_DocumentosRevision",
                    commandType: CommandType.StoredProcedure
                ).ToList();
            }
        }
        public List<Documentos_Guarco> DocumentosAprobado()
        {
            using (var ConexionSQL = new SqlConnection(_IConfiguration.GetConnectionString("ConexionSQLServer")))
            {
                return ConexionSQL.Query<Documentos_Guarco>(
                    "PA_DocumentosAprobado",
                    commandType: CommandType.StoredProcedure
                ).ToList();
            }
        }
        public bool Modificardocumentos(Documentos_Guarco pDocumentos_Guarco)
        {
            DynamicParameters parameters = new DynamicParameters();

            parameters.Add("@id_documento", pDocumentos_Guarco.id_documento, DbType.Int64, ParameterDirection.Input);
            parameters.Add("@Codigo", pDocumentos_Guarco.codigo, DbType.String, ParameterDirection.Input);
            parameters.Add("@Nombre", pDocumentos_Guarco.nombre, DbType.String, ParameterDirection.Input);
            parameters.Add("@Tipo", pDocumentos_Guarco.tipo, DbType.String, ParameterDirection.Input);
            parameters.Add("@Documento", pDocumentos_Guarco.documento, DbType.String, ParameterDirection.Input);
            parameters.Add("@Nombre_area", pDocumentos_Guarco.nombre_area, DbType.String, ParameterDirection.Input);
            parameters.Add("@Estado", pDocumentos_Guarco.estado, DbType.String, ParameterDirection.Input);
            parameters.Add("@Fecha_inicio", pDocumentos_Guarco.Fecha_inicio, DbType.DateTime, ParameterDirection.Input);
            parameters.Add("@Fecha_finalizacion", pDocumentos_Guarco.Fecha_finalizacion, DbType.DateTime, ParameterDirection.Input);
            parameters.Add("@Fecha_revision_inicio", pDocumentos_Guarco.Fecha_revision_inicio, DbType.DateTime, ParameterDirection.Input);
            parameters.Add("@Fecha_revision_finalizacion", pDocumentos_Guarco.Fecha_revision_finalizacion, DbType.DateTime, ParameterDirection.Input);
            parameters.Add("@Fecha_aprobacion", pDocumentos_Guarco.Fecha_aprobacion, DbType.DateTime, ParameterDirection.Input);

            using (var conexion_SQL = new SqlConnection(_IConfiguration.GetConnectionString("ConexionSQLServer")))
            {
                return conexion_SQL.Execute("PA_Modificardocumentos", parameters, commandType: CommandType.StoredProcedure) > 0;
            }

        }

        public bool Eliminar_documentos(int pID)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@id_documento", pID, DbType.Int32, ParameterDirection.Input);

            using (var conexionSQL = new SqlConnection(_IConfiguration.GetConnectionString("ConexionSQLServer")))
            {
                return conexionSQL.Execute("PA_Eliminardocumentos", parameters, commandType: CommandType.StoredProcedure) >= 0;
            }
        }
       
        public List<Documentos_Guarco> AprobacionArea(string pAproArea)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@Nombre_area", pAproArea, DbType.String, ParameterDirection.Input);
            using (var ConexionSQL = new SqlConnection(_IConfiguration.GetConnectionString("ConexionSQLServer")))
            {
                return (List<Documentos_Guarco>)ConexionSQL.Query<Documentos_Guarco>("PA_Consultar_aprobado_area", parameters, commandType: CommandType.StoredProcedure);
            }
        }
    }
}
