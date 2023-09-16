using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MEDICO.Models
{
    public class CitaMedica
    {
        public int ID_CITA { get; set; }
        public int ID_PACIENTE { get; set; }
        public int ID_MEDICO { get; set; }
        public DateTime FECHA_HORA { get; set; }
        public string MOTIVO { get; set; }
    }
}