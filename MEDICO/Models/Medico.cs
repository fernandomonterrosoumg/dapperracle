using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MEDICO.Models
{
    public class Medico
    {
        public string ID_MEDICO { get; set; }
        public string NOMBRE { get; set; }
        public string ESPECIALIDAD { get; set; }
        public int EXP_ANIO { get; set; }
        public int NUM_COLE { get; set; }
    }
}