using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MEDICO.Controllers
{
    public class PacienteController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }

        public ActionResult ListaPacientes()
        {
            ViewBag.Title = "Lista pacientes";
            return View();
        }
    }
}