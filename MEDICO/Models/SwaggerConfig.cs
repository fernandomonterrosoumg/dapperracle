using Swashbuckle.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace MEDICO.Models
{
    public class SwaggerConfig
    {
        public static void Register()
        {
            GlobalConfiguration.Configuration
                .EnableSwagger(c =>
                {
                    c.SingleApiVersion("v1", "Nombre de tu API");
                    c.IncludeXmlComments(AppDomain.CurrentDomain.BaseDirectory + "App_Data/YourApiDocumentation.xml"); // Ajusta la ruta al archivo XML de documentación
            })
                .EnableSwaggerUi();
        }
    }
}