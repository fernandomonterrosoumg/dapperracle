using MEDICO.Helpers;
using MEDICO.Models;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;

namespace MEDICO.Controllers
{
    public class ApiPacienteController : ApiController
    {

        [Route("api/paciente/pacientes")]
        [HttpGet]
        public async Task<IHttpActionResult> ObtenerPacientesAsync()
        {
            RespuestaHttp response = null;
            try
            {
                // Definir la consulta SQL de actualización
                string query = @"SELECT * FROM paciente order by 1 desc";

                // Crear un diccionario de parámetros con los nuevos valores y condiciones
                Dictionary<string, object> parameters = new Dictionary<string, object>();
                //parameters.Add(":codigo", 1);

                IEnumerable<Paciente> objectoSelect = await ConexionHelper.DapperExecuteQuery<Paciente>(query, parameters);

                response = new RespuestaHttp(
                        true,
                        DefResponseMessage.DEF_SUCCESS,
                        objectoSelect
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

        [Route("api/paciente/editar")]
        [HttpPost]
        public async Task<IHttpActionResult> EditarPacienteAsync([FromBody] Paciente request)
        {
            RespuestaHttp response = null;
            try
            {
                // Realiza la actualización de datos en la base de datos utilizando el ID y los datos de la solicitud.
                string query = @"UPDATE paciente SET NOMBRE = :nombre, EDAD = :edad, GENERO = :genero, FEC_ING = SYSDATE WHERE ID_PACIENTE = :idPaciente";

                Dictionary<string, object> parameters = new Dictionary<string, object>();
                parameters.Add(":nombre", request.NOMBRE);
                parameters.Add(":edad", request.EDAD);
                parameters.Add(":genero", request.GENERO);
                parameters.Add(":idPaciente", request.ID_PACIENTE);

                IEnumerable<Paciente> objectoSelect = await ConexionHelper.DapperExecuteQuery<Paciente>(query, parameters);

                response = new RespuestaHttp(
                        true,
                        DefResponseMessage.DEF_SUCCESS,
                        objectoSelect
                    );
            }
            catch (Exception ex)
            {
                response = new RespuestaHttp(false, ex.Message, null);
                return Content(HttpStatusCode.InternalServerError, response);
            }
            return Ok(response);
        }


        [Route("api/paciente/eliminar/{id}")]
        [HttpPost]
        public async Task<IHttpActionResult> EliminarPacienteAsync(int id)
        {
            RespuestaHttp response = null;
            try
            {
                // Realiza la eliminación de datos en la base de datos
                string query = @"DELETE FROM paciente WHERE ID_PACIENTE = :idPaciente";

                Dictionary<string, object> parameters = new Dictionary<string, object>();
                parameters.Add(":idPaciente", id);

                IEnumerable<Paciente> objectoSelect = await ConexionHelper.DapperExecuteQuery<Paciente>(query, parameters);

                response = new RespuestaHttp(
                        true,
                        DefResponseMessage.DEF_SUCCESS,
                        objectoSelect
                    );
            }
            catch (Exception ex)
            {
                response = new RespuestaHttp(false, ex.Message, null);
                return Content(HttpStatusCode.InternalServerError, response);
            }
            return Ok(response);
        }


        [Route("api/paciente/crear")]
        [HttpPost]
        public async Task<IHttpActionResult> CrearPacienteAsync([FromBody] Paciente request)
        {
            RespuestaHttp response = null;
            try
            {
                // Realiza la inserción de datos en la base de datos
                string query = @"INSERT INTO paciente (NOMBRE, EDAD, GENERO, FEC_ING) 
                         VALUES (:nombre, :edad, :genero, SYSDATE)";

                Dictionary<string, object> parameters = new Dictionary<string, object>();
                parameters.Add(":nombre", request.NOMBRE);
                parameters.Add(":edad", request.EDAD);
                parameters.Add(":genero", request.GENERO);

                IEnumerable<Paciente> objectoSelect = await ConexionHelper.DapperExecuteQuery<Paciente>(query, parameters);

                response = new RespuestaHttp(
                        true,
                        DefResponseMessage.DEF_SUCCESS,
                        objectoSelect
                    );
            }
            catch (Exception ex)
            {
                response = new RespuestaHttp(false, ex.Message, null);
                return Content(HttpStatusCode.InternalServerError, response);
            }
            return Ok(response);
        }
    

        // GET api/values
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
