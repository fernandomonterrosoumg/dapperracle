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
    public class ApiCitaMedicaController : ApiController
    {
        [Route("api/cita/citas")]
        [HttpGet]
        public async Task<IHttpActionResult> ObtenerCitasMedicasAsync()
        {
            RespuestaHttp response = null;
            try
            {
                // Definir la consulta SQL para obtener citas médicas
                string query = @"SELECT * FROM cita_medica";

                // Crear un diccionario de parámetros si es necesario
                Dictionary<string, object> parameters = new Dictionary<string, object>();

                // Ejecutar la consulta y obtener las citas médicas
                IEnumerable<CitaMedica> citasMedicas = await ConexionHelper.DapperExecuteQuery<CitaMedica>(query, parameters);

                response = new RespuestaHttp(
                    true,
                    DefResponseMessage.DEF_SUCCESS,
                    citasMedicas
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

        [Route("api/cita/editar")]
        [HttpPost]
        public async Task<IHttpActionResult> EditarCitaMedicaAsync([FromBody] CitaMedica request)
        {
            RespuestaHttp response = null;
            try
            {
                // Realizar la actualización de datos en la base de datos utilizando el ID y los datos de la solicitud.
                string query = @"UPDATE cita_medica SET ID_PACIENTE = :idPaciente, ID_MEDICO = :idMedico, FECHA_HORA = :fechaHora, MOTIVO = :motivo WHERE ID_CITA = :idCita";

                Dictionary<string, object> parameters = new Dictionary<string, object>();
                parameters.Add(":idPaciente", request.ID_PACIENTE);
                parameters.Add(":idMedico", request.ID_MEDICO);
                parameters.Add(":fechaHora", request.FECHA_HORA);
                parameters.Add(":motivo", request.MOTIVO);
                parameters.Add(":idCita", request.ID_CITA);

                IEnumerable<CitaMedica> citasMedicas = await ConexionHelper.DapperExecuteQuery<CitaMedica>(query, parameters);

                response = new RespuestaHttp(
                    true,
                    DefResponseMessage.DEF_SUCCESS,
                    citasMedicas
                );
            }
            catch (Exception ex)
            {
                response = new RespuestaHttp(false, ex.Message, null);
                return Content(HttpStatusCode.InternalServerError, response);
            }
            return Ok(response);
        }

        [Route("api/cita/eliminar/{id}")]
        [HttpDelete]
        public async Task<IHttpActionResult> EliminarCitaMedicaAsync(int id)
        {
            RespuestaHttp response = null;
            try
            {
                // Realizar la eliminación de datos en la base de datos
                string query = @"DELETE FROM cita_medica WHERE ID_CITA = :idCita";

                Dictionary<string, object> parameters = new Dictionary<string, object>();
                parameters.Add(":idCita", id);

                IEnumerable<CitaMedica> citasMedicas = await ConexionHelper.DapperExecuteQuery<CitaMedica>(query, parameters);

                response = new RespuestaHttp(
                    true,
                    DefResponseMessage.DEF_SUCCESS,
                    citasMedicas
                );
            }
            catch (Exception ex)
            {
                response = new RespuestaHttp(false, ex.Message, null);
                return Content(HttpStatusCode.InternalServerError, response);
            }
            return Ok(response);
        }

        [Route("api/cita/crear")]
        [HttpPost]
        public async Task<IHttpActionResult> CrearCitaMedicaAsync([FromBody] CitaMedica request)
        {
            RespuestaHttp response = null;
            try
            {
                // Realizar la inserción de datos en la base de datos
                string query = @"INSERT INTO cita_medica (ID_PACIENTE, ID_MEDICO, FECHA_HORA, MOTIVO) 
                             VALUES (:idPaciente, :idMedico, :fechaHora, :motivo)";

                Dictionary<string, object> parameters = new Dictionary<string, object>();
                parameters.Add(":idPaciente", request.ID_PACIENTE);
                parameters.Add(":idMedico", request.ID_MEDICO);
                parameters.Add(":fechaHora", request.FECHA_HORA);
                parameters.Add(":motivo", request.MOTIVO);

                IEnumerable<CitaMedica> citasMedicas = await ConexionHelper.DapperExecuteQuery<CitaMedica>(query, parameters);

                response = new RespuestaHttp(
                    true,
                    DefResponseMessage.DEF_SUCCESS,
                    citasMedicas
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
