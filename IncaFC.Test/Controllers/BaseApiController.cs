using IncaFC.DataAccess;
using IncaFC.Test.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace IncaFC.Test.Controllers
{
    public class BaseApiController : ApiController
    {
        protected IncaFCDBEntities context { set; get; } = new IncaFCDBEntities();
        private CargarDatosContext cargarDatosContext { set; get; }
        public CustomResultModel response { set; get; }
        public BaseApiController()
        {
            context = new IncaFCDBEntities();
            response = new CustomResultModel();
        }

        public CargarDatosContext CargarDatosContext()
        {
            if (cargarDatosContext == null)
            {
                cargarDatosContext = new CargarDatosContext { context = context, response = response };
            }

            return cargarDatosContext;
        }
    }
    public class CargarDatosContext
    {
        public IncaFCDBEntities context { get; set; }
        public CustomResultModel response { set; get; }
    }
}
