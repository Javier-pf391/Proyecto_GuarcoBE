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
using Microsoft.Data.Sqlite;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Runtime.InteropServices;

namespace AccesoDatos
{
    public class Documentos_GuarcoAD : IDocumentos_GuarcoAD
    {
        private readonly IConfiguration _IConfiguration;

        public Documentos_GuarcoAD(IConfiguration iConfiguration)
        {
            _IConfiguration = iConfiguration;
        }

        private IDbConnection Connection => new SqliteConnection(_IConfiguration.GetConnectionString("ConexionSQLite"));
        public async Task<bool> Crear_documentosAsync(Documentos_Guarco pDocumentos_Guarco)
        {
            using var conn = Connection;
            string sql =@"INSERT INTO Documentos_Guarco(Codigo, Nombre, Tipo, Documento, Nombre_area, Estado, Fecha_inicio, Fecha_finalizacion, Fecha_revision_inicio, Fecha_revision_finalizacion, Fecha_aprobacion) VALUES(@codigo, @nombre, @tipo, @documento, @nombre_area, @estado, @Fecha_inicio, @Fecha_finalizacion, @Fecha_revision_inicio, @Fecha_revision_finalizacion, @Fecha_aprobacion)";
            int rows = await conn.ExecuteAsync(sql,pDocumentos_Guarco).ConfigureAwait(false);
            return rows > 0;
            
        }
        public async Task<List<Documentos_Guarco>> ConsultarDocumentosAsync()
        {
            using var conn = Connection;
            string sql="SELECT * FROM Documentos_Guarco";
            var result = await conn.QueryAsync<Documentos_Guarco>(sql).ConfigureAwait(false);
            return result.ToList();

        }
        public async Task<List<Documentos_Guarco>> VerHorasAsync()
        {
            using var conn = Connection;
            string sql = @"
         SELECT
          Fecha_inicio,
          Fecha_finalizacion,
          Fecha_revision_inicio,
          Fecha_revision_finalizacion,
          Fecha_aprobacion
        FROM Documentos_Guarco";
         var result = await conn.QueryAsync<Documentos_Guarco>(sql).ConfigureAwait(false);
            return result.ToList();
        }

        public async Task<List<Documentos_Guarco>> BusquedaCodigoAsync(string pCodigo)
        {
            using var conn = Connection;

            string sql;
            object parametros;

            if (string.IsNullOrWhiteSpace(pCodigo))
            {
                sql = "SELECT * FROM Documentos_Guarco";
                parametros = null;
            }
            else
            {
                sql = "SELECT * FROM Documentos_Guarco WHERE Codigo LIKE @Codigo";
                parametros = new { Codigo = $"%{pCodigo}%" };
            }

            var resultado = await conn
                .QueryAsync<Documentos_Guarco>(sql, parametros)
                .ConfigureAwait(false);

            return resultado.ToList();
        }

        public async Task<List<Documentos_Guarco>> VerDocumentosAsync(int pID)
        {
           using var conn = Connection;
            const string sql =@"SELECT * FROM Documentos_Guarco WHERE Id_documento = @Id_documento";

            var result = await conn
                .QueryAsync<Documentos_Guarco>(sql,new { Id_documento = pID })
                .ConfigureAwait(false);
            return result.ToList();

        }
        public async Task<List<Documentos_Guarco>> DocumentosElaboracionAsync()
        {
            using var conn = Connection;
            string sql=@"SELECT * FROM Documentos_Guarco WHERE Estado = 'Elaboracion'";

            var result = await conn
                .QueryAsync<Documentos_Guarco> (sql).ConfigureAwait(false);
            return result.ToList();

        }
        public async Task<List<Documentos_Guarco>> DocumentosRevisionAsync()
        {
            using var conn = Connection;
            string sql = @"SELECT * FROM Documentos_Guarco WHERE Estado = 'Revision'";

            var result = await conn
                .QueryAsync<Documentos_Guarco>(sql).ConfigureAwait(false);
            return result.ToList();

        }
        public async Task<List<Documentos_Guarco>> DocumentosAprobadoAsync()
        {
            using var conn = Connection;
            string sql = @"SELECT * FROM Documentos_Guarco WHERE Estado = 'Aprobado'";


            var result = await conn
                .QueryAsync<Documentos_Guarco>(sql).ConfigureAwait(false);
            return result.ToList();
        }
        public async Task<bool> Modificar_documentosAsync(Documentos_Guarco pDocumentos_Guarco)
        {
            using var conn = Connection;
            {
                var parameters = new
                {
                    pDocumentos_Guarco.id_documento,
                    pDocumentos_Guarco.codigo,
                    pDocumentos_Guarco.nombre,
                    pDocumentos_Guarco.tipo,
                    pDocumentos_Guarco.documento,
                    pDocumentos_Guarco.nombre_area,
                    pDocumentos_Guarco.estado,
                    pDocumentos_Guarco.Fecha_inicio,
                    pDocumentos_Guarco.Fecha_finalizacion,
                    pDocumentos_Guarco.Fecha_revision_inicio,
                    pDocumentos_Guarco.Fecha_revision_finalizacion,
                    pDocumentos_Guarco.Fecha_aprobacion
                };

                var sql = @"
        UPDATE Documentos_Guarco 
        SET 
            Codigo = @codigo, 
            Nombre = @nombre, 
            Tipo = @tipo, 
            Documento = @documento, 
            Nombre_area = @nombre_area, 
            Estado = @estado, 
            Fecha_inicio = @Fecha_inicio, 
            Fecha_finalizacion = @Fecha_finalizacion, 
            Fecha_revision_inicio = @Fecha_revision_inicio, 
            Fecha_revision_finalizacion = @Fecha_revision_finalizacion, 
            Fecha_aprobacion = @Fecha_aprobacion 
        WHERE Id_documento = @id_documento";

                var result = await conn.ExecuteAsync(sql, parameters);
                return result > 0;
            }

        }

        public async Task<bool> Eliminar_documentosAsync(int pID)
        {
            using var conn = Connection;

            const string sql = @"DELETE FROM Documentos_Guarco WHERE Id_documento = @Id_documento";

            var result = await conn.ExecuteAsync(sql, new { Id_documento = pID });
            return result > 0;
        }
       
        public async Task<List<Documentos_Guarco>> AprobacionAreaAsync(string pAproArea)
        {
            using var connection = Connection;

            string sql;
            object param;

            if (string.IsNullOrWhiteSpace(pAproArea))
            {
                sql = "SELECT * FROM Documentos_Guarco WHERE Estado = 'Aprobado'";
                param = new { };
            }
            else
            {
                sql = "SELECT * FROM Documentos_Guarco WHERE Estado = 'Aprobado' AND Nombre_area LIKE @Nombre_area";
                param = new { Nombre_area = $"%{pAproArea}%" };
            }

            var result = await connection.QueryAsync<Documentos_Guarco>(sql, param);
            return result.AsList();
        }
    }
}
