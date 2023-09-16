using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MEDICO.Models
{
    public class ConsultaMedica
    {
        public int ID_PACIENTE { get; set; }
        public int ID_MEDICO { get; set; }
        public string NOMBRE { get; set; }
        public int ID_CITA { get; set; }
        public DateTime FECHA_HORA { get; set; }
        public string MOTIVO { get; set; }
        public string ESPECIALIDAD { get; set; }
        public int EXP_ANIO { get; set; }
        public int NUM_COLE { get; set; }
        public string NOMBRE1 { get; set; }
        public int EDAD { get; set; }
        public string GENERO { get; set; }
        public DateTime FEC_ING { get; set; }
    }
}