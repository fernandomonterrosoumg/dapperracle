using MEDICO.Helpers;
using MEDICO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace MEDICO.Controllers
{
    public class ApiGeneralController : ApiController
    {
        [Route("api/consultaMedica")]
        [HttpGet]
        public async Task<IHttpActionResult> ObtenerConsultaMedica()
        {
            RespuestaHttp response = null;
            try
            {
                // Definir la consulta SQL
                string query = @"
            SELECT
                b.id_paciente,
                b.id_medico,
                a.nombre,
                b.id_cita,
                b.fecha_hora,
                b.motivo,
                a.especialidad,
                a.exp_anio,
                a.num_cole,
                c.nombre AS nombre1,
                c.edad,
                c.genero,
                c.fec_ing
            FROM
                medico a
                INNER JOIN cita_medica b ON a.id_medico = b.id_medico
                INNER JOIN paciente c ON c.id_paciente = b.id_paciente";

                Dictionary<string, object> parameters = new Dictionary<string, object>();
                // Si tienes parámetros, agrégalos aquí

                IEnumerable<ConsultaMedica> resultados = await ConexionHelper.DapperExecuteQuery<ConsultaMedica>(query, parameters);

                response = new RespuestaHttp(
                    true,
                    DefResponseMessage.DEF_SUCCESS,
                    resultados
                );
            }
            catch (Exception ex)
            {
                response = new RespuestaHttp(false, ex.Message, null);
                return Content(HttpStatusCode.InternalServerError, response);
            }
            return Ok(response);
        }
    }
}
