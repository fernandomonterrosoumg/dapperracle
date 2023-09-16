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
    public class ApiMedicoController : ApiController
    {

        [Route("api/medico/medicos")]
        [HttpGet]
        public async Task<IHttpActionResult> ObtenerMedicosAsync()
        {
            RespuestaHttp response = null;
            try
            {
                // Definir la consulta SQL para obtener médicos
                string query = @"SELECT * FROM medico";

                // Crear un diccionario de parámetros si es necesario
                Dictionary<string, object> parameters = new Dictionary<string, object>();

                // Ejecutar la consulta y obtener los médicos
                IEnumerable<Medico> medicos = await ConexionHelper.DapperExecuteQuery<Medico>(query, parameters);

                response = new RespuestaHttp(
                    true,
                    DefResponseMessage.DEF_SUCCESS,
                    medicos
                );
            }
            catch (Exception ex)
            {
                response = new RespuestaHttp(
                    false,
                    ex.Message,
                    null
                );
                return Content(HttpStatusCode.InternalServerError, response);
            }
            return Ok(response);
        }

        [Route("api/medico/editar")]
        [HttpPost]
        public async Task<IHttpActionResult> EditarMedicoAsync([FromBody] Medico request)
        {
            RespuestaHttp response = null;
            try
            {
                // Realiza la actualización de datos en la base de datos utilizando el ID y los datos de la solicitud.
                string query = @"UPDATE medico SET NOMBRE = :nombre, ESPECIALIDAD = :especialidad, EXP_ANIO = :exp_anio, NUM_COLE = :num_cole WHERE ID_MEDICO = :idMedico";

                Dictionary<string, object> parameters = new Dictionary<string, object>();
                parameters.Add(":nombre", request.NOMBRE);
                parameters.Add(":especialidad", request.ESPECIALIDAD);
                parameters.Add(":exp_anio", request.EXP_ANIO);
                parameters.Add(":num_cole", request.NUM_COLE);
                parameters.Add(":idMedico", request.ID_MEDICO);

                IEnumerable<Medico> medicos = await ConexionHelper.DapperExecuteQuery<Medico>(query, parameters);

                response = new RespuestaHttp(
                    true,
                    DefResponseMessage.DEF_SUCCESS,
                    medicos
                );
            }
            catch (Exception ex)
            {
                response = new RespuestaHttp(false, ex.Message, null);
                return Content(HttpStatusCode.InternalServerError, response);
            }
            return Ok(response);
        }

        [Route("api/medico/eliminar/{id}")]
        [HttpDelete]
        public async Task<IHttpActionResult> EliminarMedicoAsync(string id)
        {
            RespuestaHttp response = null;
            try
            {
                // Realiza la eliminación de datos en la base de datos
                string query = @"DELETE FROM medico WHERE ID_MEDICO = :idMedico";

                Dictionary<string, object> parameters = new Dictionary<string, object>();
                parameters.Add(":idMedico", id);

                IEnumerable<Medico> medicos = await ConexionHelper.DapperExecuteQuery<Medico>(query, parameters);

                response = new RespuestaHttp(
                    true,
                    DefResponseMessage.DEF_SUCCESS,
                    medicos
                );
            }
            catch (Exception ex)
            {
                response = new RespuestaHttp(false, ex.Message, null);
                return Content(HttpStatusCode.InternalServerError, response);
            }
            return Ok(response);
        }

        [Route("api/medico/crear")]
        [HttpPost]
        public async Task<IHttpActionResult> CrearMedicoAsync([FromBody] Medico request)
        {
            RespuestaHttp response = null;
            try
            {
                // Realiza la inserción de datos en la base de datos
                string query = @"INSERT INTO medico (NOMBRE, ESPECIALIDAD, EXP_ANIO, NUM_COLE) 
                             VALUES (:nombre, :especialidad, :exp_anio, :num_cole)";

                Dictionary<string, object> parameters = new Dictionary<string, object>();
                parameters.Add(":nombre", request.NOMBRE);
                parameters.Add(":especialidad", request.ESPECIALIDAD);
                parameters.Add(":exp_anio", request.EXP_ANIO);
                parameters.Add(":num_cole", request.NUM_COLE);

                IEnumerable<Medico> medicos = await ConexionHelper.DapperExecuteQuery<Medico>(query, parameters);

                response = new RespuestaHttp(
                    true,
                    DefResponseMessage.DEF_SUCCESS,
                    medicos
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
